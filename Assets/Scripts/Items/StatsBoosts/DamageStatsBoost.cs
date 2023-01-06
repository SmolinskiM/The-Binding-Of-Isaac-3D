using UnityEngine;

[CreateAssetMenu(fileName = "DamageStatsBoost", menuName = "StatsBoost/DamageStatsBoost")]
public class DamageStatsBoost : StatsBoost
{
    public override void Apply(PlayerStats playerStats, float valueBoost)
    {
        playerStats.damage += valueBoost;
    }
}
