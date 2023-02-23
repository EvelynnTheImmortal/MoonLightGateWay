using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardQuestGiver : MonoBehaviour
{
	public BillboardQuestClientEV[] BquestClients = new BillboardQuestClientEV[2];
	private int questStep = 0;
	public string triggerText = "Talk";

	private GameObject player;
	private GameObject questData;

	public void Talking()
	{
		if (EventActivator.onInteracting || Time.timeScale == 0)
		{
			return;
		}
		bool q = BquestClients[questStep].ActivateQuest(player);
		if (q && questStep < BquestClients.Length)
		{
			BquestClients[questStep].enter = false; //Reset Enter Variable of last client
			questStep++;
			if (questStep >= BquestClients.Length)
			{
				questStep = BquestClients.Length - 1;
				return;
			}
			BquestClients[questStep].s = 0;
			BquestClients[questStep].enter = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			player = other.gameObject;
			CheckQuestSequence();

			BquestClients[questStep].s = 0;
			BquestClients[questStep].enter = true;

			if (player.GetComponent<AttackTrigger>())
				player.GetComponent<AttackTrigger>().GetActivator(this.gameObject, "Talking", triggerText);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			BquestClients[questStep].s = 0;
			BquestClients[questStep].enter = false;

			if (player.GetComponent<AttackTrigger>())
				player.GetComponent<AttackTrigger>().RemoveActivator(this.gameObject);
		}
	}

	public void CheckQuestSequence()
	{
		bool c = true;
		while (c == true)
		{
			int id = BquestClients[questStep].questId;
			questData = BquestClients[questStep].questData;
			int qprogress = player.GetComponent<QuestStat>().questProgress[id]; //Check Queststep
			int finish = questData.GetComponent<QuestData>().questData[id].finishProgress;
			if (qprogress >= finish + 9)
			{
				questStep++;
				if (questStep >= BquestClients.Length)
				{
					questStep = BquestClients.Length - 1;
					c = false; // End Loop
				}
			}
			else
			{
				c = false; // End Loop
			}
		}
	}

	///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
