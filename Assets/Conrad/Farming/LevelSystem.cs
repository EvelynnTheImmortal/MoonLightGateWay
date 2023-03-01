using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

using static GameFarmingEvent;

public class LevelSystem : MonoBehaviour
{
    //private int xPNow;
    //private int level;
    //private int xpToNext;

    //[SerializeField] private GameObject levelPanel;
    //[SerializeField] private GameObject StarPanel;
    //[SerializeField] private GameObject lvlWindowPrefab;

    //private Slider slider;
    //private TMP_Text xpText;
    //private TMP_Text lvlText;
    //private Image starImage;

    //private static bool initialized;
    //private static Dictionary<int, int> xpToNextLevel = new Dictionary<int, int>();
    //private static Dictionary<int, int[]> lvlReward = new Dictionary<int, int[]>();

    //private void Awake()
    //{
    //    slider = levelPanel.GetComponent<Slider>();
    //    xpText = levelPanel.transform.Find("XP text").GetComponent<TMP_Text>();
    //    starImage = StarPanel.transform.Find("Star").GetComponent<Image>();
    //    lvlText = starImage.transform.GetChild(0).GetComponent<TMP_Text>();

    //    if (!initialized)
    //    {
    //        Initialize();
    //    }

    //    xpToNextLevel.TryGetValue(level, out xpToNext);


    //}

    //private static void Initialize()
    //{
    //    try
    //    {
    //        //path to the csv file
    //        string path = Path.Combine(Directory.GetCurrentDirectory(), @"levelsXP");
            
    //        TextAsset textAsset = Resources.Load<TextAsset>(path);
    //        string[] lines = textAsset.text.Split(separator: '\n');
    //        print(lines[0]);

    //        //xpToNextLevel = new Dictionary<int, int>(capacity: lines.Length);

    //        for (int i = 0; i < lines.Length; i++)
    //        {
    //            string[] columns = lines[i].Split(separator: ',');
    //            print(columns[0]);

    //            int lvl = -1;
    //            int xp = -1;
    //            int curr1 = -1;
    //            int curr2 = -1;

    //            int.TryParse(columns[0], out lvl);
    //            int.TryParse(columns[1], out xp);
    //            int.TryParse(columns[2], out curr1);
    //            int.TryParse(columns[3], out curr2);

    //            print(lvl);

    //            if (lvl >= 0 && xp > 0)
    //            {
    //                if (!xpToNextLevel.ContainsKey(lvl))
    //                {
    //                    xpToNextLevel.Add(lvl, xp);
    //                    lvlReward.Add(lvl, new[] { curr1, curr2 });
    //                }
    //            }
    //        }
    //    }
    //    catch(Exception ex)
    //    {
    //        Debug.Log(ex.Message);
    //    }

    //    initialized = true;
    //}

    //private void Start()
    //{
    //    EventManager.Instance.AddListener<XPAddedGameEvent>(OnXPAdded);
    //    EventManager.Instance.AddListener<LevelChangedGameEvent>(OnLevelChanged);

    //    UpdateUI();
    //}

    //private void UpdateUI()
    //{
    //    float fill = (float)xPNow / xpToNext;
    //    slider.value = fill;
    //    xpText.text = xPNow + "/" + xpToNext;
    //}

    //private void OnXPAdded(XPAddedGameEvent info)
    //{
    //    xPNow += info.amount;

    //    UpdateUI();

    //    if (xPNow >= xpToNext)
    //    {
    //        level++;
    //        LevelChangedGameEvent levelChange = new LevelChangedGameEvent(level);
    //        EventManager.Instance.QueueEvent(levelChange);
    //    }
    //}

    //private void OnLevelChanged(LevelChangedGameEvent info)
    //{
    //    xPNow -= xpToNext;
    //    xpToNext = xpToNextLevel[info.newLvl];
    //    lvlText.text = (info.newLvl + 1).ToString();
    //    UpdateUI();

    //    //GameObject window = Instantiate(lvlWindowPrefab, GameManager.current.canvas.transform);

    //    //initialize texts and images here

    //    window.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(call: delegate
    //    {
    //        Destroy(window);
    //    });

    //    CurrencyChangeGameEvent currencyInfo = new CurrencyChangeGameEvent(lvlReward[info.newLvl][0], CurrencyType.coins);
    //    EventManager.Instance.QueueEvent(currencyInfo);

    //    currencyInfo = new CurrencyChangeGameEvent(lvlReward[info.newLvl][1], CurrencyType.crystals);
    //    EventManager.Instance.QueueEvent(currencyInfo);

    //}
}
