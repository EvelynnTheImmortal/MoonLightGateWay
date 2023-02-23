using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SideQuestData : MonoBehaviour
{
	public List<GameObject> SQ = new List<GameObject>();
	public int SideQuestNum = 0;
	public GameObject ButtonPrefabContainer;
	public GameObject[] ButtonPrefabs;
	//
	public GameObject Quest2;

	//
	private int i = 0;


	public GameObject itemData;
	[System.Serializable]
	public class SideQuest
	{
		public string questName = "";
		public string description;
		public int finishProgress = 5;
		public int rewardCash = 100;
		public int rewardExp = 100;
		public int[] rewardItemID;
		public int[] rewardEquipmentID;
		public bool showProgress = true;
		public bool cantCancel = false;
	}

	public SideQuest[] questData = new SideQuest[3];

    private void Awake()
    {
		SQ.Add(Quest2);
    }

    public void QuestClear(int id, GameObject player)
	{
		//Get Rewards
		player.GetComponent<Inventory>().cash += questData[id].rewardCash; //Add Cash
		player.GetComponent<Status>().GainEXP(questData[id].rewardExp); //Get EXP
		int i = 0;
		if (questData[id].rewardItemID.Length > 0)
		{   //Add Items
			i = 0;
			while (i < questData[id].rewardItemID.Length)
			{
				player.GetComponent<Inventory>().AddItem(questData[id].rewardItemID[i], 1);
				i++;
			}
		}

		if (questData[id].rewardEquipmentID.Length > 0)
		{   //Add Equipments
			i = 0;
			while (i < questData[id].rewardEquipmentID.Length)
			{
				player.GetComponent<Inventory>().AddEquipment(questData[id].rewardEquipmentID[i]);
				i++;
			}
		}
		if (SideQuestNum <= SQ.Count)
		{
			if (i < SQ.Count)
			{
				Instantiate(SQ[i], ButtonPrefabContainer.transform.position, Quaternion.identity, ButtonPrefabContainer.transform);
				i++;
				SideQuestNum++;
			}
		}
	}
}
