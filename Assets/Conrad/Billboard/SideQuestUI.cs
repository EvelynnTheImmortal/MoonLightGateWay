using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideQuestUI : MonoBehaviour
{
	public Text[] questName = new Text[5];
	public Text[] questDescription = new Text[5];
	public GameObject[] cancelButton = new GameObject[5];
	public GameObject player;

	public SideQuestData database;

	public Text pageText;
	public GameObject pagePanel;
	private int maxPage = 1;
	private int page = 0;
	private int cPage = 0;
	private int questLength = 5;

	void SetMaxPage()
	{
		//Set Max Page
		if (!player && GlobalStatus.mainPlayer)
		{
			player = GlobalStatus.mainPlayer;
		}
		if (player)
		{
			questLength = 0;
			for (int a = 0; a < player.GetComponent<SideQuestStat>().SidequestSlot.Length; a++)
			{
				if (player.GetComponent<SideQuestStat>().SidequestSlot[a] > 0)
				{
					questLength++;
				}
			}
		}
		maxPage = questLength / questName.Length;
		if (questLength % questName.Length != 0)
		{
			maxPage += 1;
		}
		if (maxPage > 1 && pagePanel)
		{
			pagePanel.SetActive(true);
		}
		else if (pagePanel)
		{
			pagePanel.SetActive(false);
		}
	}

	public void UpdateQuestDetails()
	{
		if (!player)
		{
			return;
		}
		for (int a = 0; a < questName.Length; a++)
		{
			cancelButton[a].SetActive(false);
		}
		SideQuestStat pq = player.GetComponent<SideQuestStat>();
		for (int a = 0; a < questName.Length; a++)
		{
			questName[a].GetComponent<Text>().text = database.questData[pq.SidequestSlot[a + cPage]].questName;
			if (database.questData[pq.SidequestSlot[a]].showProgress)
			{
				questDescription[a].GetComponent<Text>().text = database.questData[pq.SidequestSlot[a + cPage]].description + " (" + pq.SidequestProgress[pq.SidequestSlot[a + cPage]].ToString() + " / " + database.questData[pq.SidequestSlot[a + cPage]].finishProgress + ")";
			}
			else
			{
				questDescription[a].GetComponent<Text>().text = database.questData[pq.SidequestSlot[a + cPage]].description;
			}

			if (a + cPage < questLength && pq.SidequestSlot[a + cPage] > 0)
			{
				questDescription[a].gameObject.SetActive(true);
				//cancelButton[a].SetActive(true);
				if (cancelButton.Length > 0)
				{
					if (!database.questData[pq.SidequestSlot[a]].cantCancel)
					{
						cancelButton[a].SetActive(true);
					}
				}
			}
			else
			{
				questDescription[a].gameObject.SetActive(false);
				cancelButton[a].SetActive(false);
			}
		}
	}

	public void CancelQuest(int qid)
	{
		if (!player)
		{
			return;
		}
		SideQuestStat pq = player.GetComponent<SideQuestStat>();
		pq.SidequestProgress[pq.SidequestSlot[qid]] = 0;
		pq.SidequestSlot[qid] = 0;
		pq.SortQuest();
		UpdateQuestDetails();
	}

	public void CloseMenu()
	{
		Time.timeScale = 1.0f;
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
		GlobalStatus.menuOn = false;
		gameObject.SetActive(false);
	}

	public void NextPage()
	{
		if (page < maxPage - 1)
		{
			page++;
			cPage = page * questName.Length;
		}
		if (pageText)
		{
			int p = page + 1;
			pageText.GetComponent<Text>().text = p.ToString();
		}
		UpdateQuestDetails();
	}

	public void PreviousPage()
	{
		if (page > 0)
		{
			page--;
			cPage = page * questName.Length;
		}
		if (pageText)
		{
			int p = page + 1;
			pageText.GetComponent<Text>().text = p.ToString();
		}
		UpdateQuestDetails();
	}

	public void ResetPage()
	{
		page = 0;
		cPage = 0;
		if (pageText)
		{
			int p = page + 1;
			pageText.GetComponent<Text>().text = p.ToString();
		}
		SetMaxPage();
		UpdateQuestDetails();
	}
}
