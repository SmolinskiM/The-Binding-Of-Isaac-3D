using UnityEngine;

[CreateAssetMenu(fileName = "RangeStatsBoost", menuName = "StatsBoost/RangeStatsBoost")]
public class RangeStatsBoost : StatsBoost
{
    public override void Apply(PlayerStats playerStats, float valueBoost)
    {
        playerStats.range += valueBoost;
    }
}
