using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHaving : SingletoneMonobehaviour<ItemHaving>
{
    private PlayerStats playerStats;
    private List<ItemsData> itemsDatasHaving;

    public List<ItemsData> ItemsDatasHaving { get { return itemsDatasHaving; } }

    public void AddItem(ItemsData itemsData)
    {
        foreach(StatsBoostData statsBoostData in itemsData.Stats)
        {
            statsBoostData.StatsBoost.Apply(playerStats, statsBoostData.ValueBoost);
        }

        itemsDatasHaving.Add(itemsData);
    }

    public void RemoveItem(ItemsData itemsData)
    {
        foreach (StatsBoostData statsBoostData in itemsData.Stats)
        {
            statsBoostData.StatsBoost.Remove(playerStats, statsBoostData.ValueBoost);
        }

        itemsDatasHaving.Remove(itemsData);
    }
}
