using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemPassive")]
public class ItemsData : ScriptableObject
{
    [SerializeField] private List<StatsBoost> stats;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private List<ItemPools> itemPools;

    public Sprite ItemSprite { get { return itemSprite; } }
    public List<StatsBoost> Stats { get { return stats; } }
    public List<ItemPools> ItemPools { get { return itemPools; } }
}

[CreateAssetMenu(fileName = "ItemDataActive", menuName = "Item/ItemActive")]
public class ItemsDataActive : ItemsData
{
    [SerializeField] private int chargeMax;

    public int ChargeMax { get { return chargeMax; } }
}
