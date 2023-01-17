using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Gun,
    Ammunitions
}

public class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [SerializeField] public string objectName;

}
