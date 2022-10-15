using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemList")]
public class ItemsDataList : ScriptableObject
{
    [SerializeField] private List<ItemsData> itemsData;

    public List<ItemsData> ItemsData { get { return itemsData; } }
}
