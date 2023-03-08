using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolBarPanel : FarmingItemPanel
{
    [SerializeField] FarmingToolBarController toolbarController;

    private void Start()
    {
        Init();
        toolbarController.onChange += Highlight;
        Highlight(0);
    }

    private void Awake()
    {
        Init();
        
        Highlight(0);
    }
    public override void OnClick(int id)
    {
        toolbarController.Set(id);
        Highlight(id);
    }

    int currentSelectedTool;

    public void Highlight(int id)
    {
        buttons[currentSelectedTool].Highlight(false);
        currentSelectedTool = id;
        buttons[currentSelectedTool].Highlight(true);
    }
}
