using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardQuestClientEV : MonoBehaviour
{
	public int questId = 1;
	public GameObject questData;
	[HideInInspector]
	public bool enter = false;
	[HideInInspector]
	public int s = 0;

	private GameObject player;

	public EventActivator talkingEvent;
	public EventActivator ongoingQuestEvent;
	public EventActivator finishQuestEvent;
	public EventActivator alreadyFinishQuestEvent;
	public EventActivator questFullEvent;

	private bool acceptQuest = false;
	public bool trigger = false;
	public string showText = "";
	private bool thisActive = false;
	private bool questFinish = false;
	public string sendMsgWhenTakeQuest = "";
	public string sendMsgWhenQuestComplete = "";
	public bool repeatable = false;

	void Update()
	{
		if (questFullEvent && questFullEvent.eventRunning)
		{
			return;
		}
		if (Input.GetKeyDown("e") && enter && thisActive)
		{
			SetDialogue();
		}
	}

	public void SetDialogue()
	{
		if (!player)
		{
			player = GameObject.FindWithTag("Player");
		}

		int ongoing = player.GetComponent<SideQuestStat>().CheckQuestProgress(questId);
		int finish = questData.GetComponent<SideQuestData>().questData[questId].finishProgress;
		int qprogress = player.GetComponent<SideQuestStat>().SidequestProgress[questId];
		if (qprogress >= finish + 9)
		{
			if (finishQuestEvent.runEvent > 0 || finishQuestEvent.eventRunning)
			{
				return;
			}
			alreadyFinishQuestEvent.player = player;
			alreadyFinishQuestEvent.ActivateEvent();
			print("Already Clear");
			return;
		}
		if (acceptQuest)
		{
			if (ongoing >= finish)
			{ //Quest Complete
				finishQuestEvent.player = player;
				finishQuestEvent.ActivateEvent();
				FinishQuest();
			}
			else
			{
				//Ongoing
				if (talkingEvent.runEvent > 0 || talkingEvent.eventRunning)
				{
					questFullEvent.player = player;
					questFullEvent.ActivateEvent();
					return;
				}
				ongoingQuestEvent.player = player;
				ongoingQuestEvent.ActivateEvent();
			}
		}
		else
		{
			int ll = player.GetComponent<SideQuestStat>().SidequestSlot.Length;
			if (questFullEvent && player.GetComponent<SideQuestStat>().SidequestSlot[ll - 1] > 0)
			{
				questFullEvent.player = player;
				questFullEvent.ActivateEvent();
				return;
			}
			//Before Take the quest
			talkingEvent.player = player;
			talkingEvent.ActivateEvent();
			TakeQuest();
		}
	}

	public void TakeQuest()
	{
		//StartCoroutine(AcceptQuest());
		AcceptQuest();
		CloseTalk();
	}

	public void FinishQuest()
	{
		questData.GetComponent<SideQuestData>().QuestClear(questId, player);
		player.GetComponent<SideQuestStat>().Clear(questId);
		print("Clear");
		questFinish = true;
		if (sendMsgWhenQuestComplete != "")
		{
			SendMessage(sendMsgWhenQuestComplete);
		}
		CloseTalk();
		if (repeatable)
		{
			player.GetComponent<SideQuestStat>().SidequestProgress[questId] = 0;
			questFinish = false;
		}
	}

	public void AcceptQuest()
	{
		bool full = player.GetComponent<SideQuestStat>().AddQuest(questId);
		if (full)
		{
			//Quest Full
			/*if(questFullEvent){
				questFullEvent.player = player;
				questFullEvent.ActivateEvent();
			}*/
		}
		else
		{
			acceptQuest = player.GetComponent<SideQuestStat>().CheckQuestSlot(questId);
			if (sendMsgWhenTakeQuest != "")
			{
				SendMessage(sendMsgWhenTakeQuest);
			}
		}
	}

	public void CheckQuestCondition()
	{
		SideQuestData quest = questData.GetComponent<SideQuestData>();
		int progress = player.GetComponent<SideQuestStat>().CheckQuestProgress(questId);

		if (progress >= quest.questData[questId].finishProgress)
		{
			//Quest Clear
			quest.QuestClear(questId, player);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!trigger)
		{
			return;
		}
		if (other.tag == "Player")
		{
			s = 0;
			player = other.gameObject;
			acceptQuest = player.GetComponent<SideQuestStat>().CheckQuestSlot(questId);
			enter = true;
			thisActive = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (!trigger)
		{
			return;
		}
		if (other.tag == "Player")
		{
			s = 0;
			enter = false;
			CloseTalk();
		}
		thisActive = false;
	}

	void CloseTalk()
	{
		//Time.timeScale = 1.0f;
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
		s = 0;
	}

	public bool ActivateQuest(GameObject p)
	{
		player = p;
		acceptQuest = player.GetComponent<SideQuestStat>().CheckQuestSlot(questId);
		thisActive = false;
		trigger = false;
		SetDialogue();
		return questFinish;
	}
}
