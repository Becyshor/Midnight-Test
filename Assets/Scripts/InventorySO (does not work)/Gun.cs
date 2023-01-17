using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Inventory System/Items/Gun")]
public class Gun : ItemObject
{
    private void Awake()
    {
        type = ItemType.Gun;
    }
}
