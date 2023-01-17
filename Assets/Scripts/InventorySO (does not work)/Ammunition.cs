using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ammo", menuName = "Inventory System/Items/Ammo")]
public class Ammunition : ItemObject
{
    private void Awake()
    {
        type = ItemType.Ammunitions;
    }
}
