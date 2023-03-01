using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "GameObjects/ShopItem", order = 0)]
public class ShopItem : MonoBehaviour
{
    public string Name = "Default";

}

public enum ObjectType
{ 
    AnimalHomes,
    Animals,
    ProductionBuildings,
    TreesBushes,
    Decorations
}
