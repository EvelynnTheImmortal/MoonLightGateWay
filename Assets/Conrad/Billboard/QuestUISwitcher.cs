using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUISwitcher : MonoBehaviour
{
    public GameObject QuestMenuUI, SideQuestMenuUI;
    public void OpenQuestUI()
    {
        QuestMenuUI.SetActive(true);
        SideQuestMenuUI.SetActive(false);
    }

    public void OpenSideQuestUI()
    {
        SideQuestMenuUI.SetActive(true);
        QuestMenuUI.SetActive(false);
    }
}
