using UnityEngine;

[CreateAssetMenu(fileName = "SpeedStatsBoost", menuName = "StatsBoost/SpeedStatsBoost")]
public class SpeedStatsBoost : StatsBoost
{
    public override void Apply(PlayerStats playerStats, float valueBoost)
    {
        playerStats.speed += valueBoost;
    }
}
