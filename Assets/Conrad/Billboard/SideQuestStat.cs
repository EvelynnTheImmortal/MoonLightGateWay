using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideQuestStat : MonoBehaviour
{
	public SideQuestData SideQuestDatabase;

	public int[] SidequestProgress = new int[20];
	public int[] SidequestSlot = new int[5];

	void Start()
	{
		// If Array Length of questProgress Variable < QuestData.Length
		if (SidequestProgress.Length < SideQuestDatabase.questData.Length)
		{
			SidequestProgress = new int[SideQuestDatabase.questData.Length];
		}
	}

	public bool AddQuest(int id)
	{
		bool full = false;
		bool geta = false;

		int pt = 0;
		while (pt < SidequestSlot.Length && !geta)
		{
			if (SidequestSlot[pt] == id)
			{
				print("You Already Accept this Quest");
				geta = true;
			}
			else if (SidequestSlot[pt] == 0)
			{
				SidequestSlot[pt] = id;
				geta = true;
				if (GetComponent<UiMaster>())
				{
					GetComponent<UiMaster>().ShowQuestWarning();
				}
			}
			else
			{
				pt++;
				if (pt >= SidequestSlot.Length)
				{
					full = true;
					print("Full");
				}
			}
		}
		return full;
	}

	public void SortQuest()
	{
		int pt = 0;
		int nextp = 0;
		bool clearr = false;
		while (pt < SidequestSlot.Length)
		{
			if (SidequestSlot[pt] == 0)
			{
				nextp = pt + 1;
				while (nextp < SidequestSlot.Length && !clearr)
				{
					if (SidequestSlot[nextp] > 0)
					{
						//Fine Next Slot and Set
						SidequestSlot[pt] = SidequestSlot[nextp];
						SidequestSlot[nextp] = 0;
						clearr = true;
					}
					else
					{
						nextp++;
					}
				}
				//Continue New Loop
				clearr = false;
				pt++;
			}
			else
			{
				pt++;
			}
		}
	}

	public bool Progress(int id)
	{
		bool haveQuest = false;
		//Check for You have a quest ID match to one of Quest Slot
		for (int n = 0; n < SidequestSlot.Length; n++)
		{
			if (SidequestSlot[n] == id && id != 0)
			{
				// Check If The Progress of this quest < Finish Progress then increase 1 of Quest Progress Variable
				if (SidequestProgress[id] < SideQuestDatabase.questData[SidequestSlot[n]].finishProgress)
				{
					SidequestProgress[id] += 1;
					haveQuest = true;
					if (GetComponent<UiMaster>() && SidequestProgress[id] >= SideQuestDatabase.questData[SidequestSlot[n]].finishProgress)
					{
						GetComponent<UiMaster>().ShowQuestWarning();
					}
				}
				print("Quest Slot =" + n);
			}
		}
		return haveQuest;
	}
	//-----------------------------------------------

	public bool CheckQuestSlot(int id)
	{
		//Check for You have a quest ID match to one of Quest Slot
		bool exist = false;
		for (int n = 0; n < SidequestSlot.Length; n++)
		{
			if (SidequestSlot[n] == id && id != 0)
			{
				//You Have this quest in the slot
				exist = true;
			}
		}
		return exist;
	}

	public int CheckQuestProgress(int id)
	{
		//Check for You have a quest ID match to one of Quest Slot
		int qProgress = 0;
		for (int n = 0; n < SidequestSlot.Length; n++)
		{
			if (SidequestSlot[n] == id && id != 0)
			{
				//You Have this quest in the slot
				qProgress = SidequestProgress[id];
			}
		}
		return qProgress;
	}

	//---------------------------------------

	public void Clear(int id)
	{
		//Check for You have a quest ID match to one of Quest Slot
		for (int n = 0; n < SidequestSlot.Length; n++)
		{
			if (SidequestSlot[n] == id && id != 0)
			{
				//QuestData data = questDataBase.GetComponent<QuestData>();
				SidequestProgress[id] += 10;
				SidequestSlot[n] = 0;
				SortQuest();
				print("Quest Slot =" + n);
			}
		}
	}
}

