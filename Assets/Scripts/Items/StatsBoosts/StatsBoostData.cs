using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatsBoostData
{
    [SerializeField] private StatsBoost statsBoost;
    [SerializeField] private float valueBoost;

    public StatsBoost StatsBoost { get { return statsBoost; } }
    public float ValueBoost { get { return valueBoost; } }
}
