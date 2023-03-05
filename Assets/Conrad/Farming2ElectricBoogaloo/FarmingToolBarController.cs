using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingToolBarController : MonoBehaviour
{
    [SerializeField] int toolbarSize = 10;
    int selectedTool;

    public Action<int> onChange;

    private void Update()
    {
        float delta = Input.mouseScrollDelta.y;
        if (delta != 0)
        {
            if (delta > 0)
            {
                selectedTool += 1;
                selectedTool = selectedTool >= toolbarSize ? 0 : selectedTool;
            }
            else
            {
                selectedTool -= 1;
                selectedTool = selectedTool < 0 ? toolbarSize - 1 : selectedTool;
            }
            //if (selectedTool > 10)
            //{
            //    selectedTool -= 10;
            //}
            //if (selectedTool < 0)
            //{
            //    selectedTool += 10;
            //}
            onChange?.Invoke(selectedTool);
            Debug.Log(selectedTool);
        }
    }

    internal void Set(int id)
    {
        selectedTool = id;
    }
}
