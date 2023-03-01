using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFarmingEvent : MonoBehaviour
{
    public class CurrencyChangeGameEvent : GameFarmingEvent
    {
        public int amount;
        public CurrencyType currencyType;

        public CurrencyChangeGameEvent(int amount, CurrencyType currencyType)
        {
            this.amount = amount;
            this.currencyType = currencyType;
        }
    }

    public class NotEnoughCurrencyGameEvent : GameFarmingEvent
    {
        public int amount;
        public CurrencyType currencyType;

        public NotEnoughCurrencyGameEvent(int amount, CurrencyType currencyType)
        {
            this.amount = amount;
            this.currencyType = currencyType;
        }
    }

    public class EnoughCurrencyGameEvent : GameFarmingEvent
    { 
        
    }

    public class XPAddedGameEvent : GameFarmingEvent
    {
        public int amount;

        public XPAddedGameEvent(int amount)
        {
            this.amount = amount;
        }
    }

    public class LevelChangedGameEvent : GameFarmingEvent
    {
        public int newLvl;

        public LevelChangedGameEvent(int currlvl)
        {
            newLvl = currlvl;
        }
    }

}
