using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUI : MonoBehaviour
{
	public GameObject menuPanel;
	public void OpenBillboard()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0.0f;
		GlobalStatus.freezeAll = true;
		GlobalStatus.mainPlayer.GetComponent<UiMaster>().CloseAllMenu();
		menuPanel.SetActive(true);
	}
	public void CloseMenu()
	{
		Time.timeScale = 1.0f;
		//Cursor.lockState = CursorLockMode.Locked;
		//Cursor.visible = false;
		GlobalStatus.menuOn = false;
		menuPanel.SetActive(false);
		//gameObject.SetActive(false);
	}
}
