using UnityEngine;

[CreateAssetMenu(fileName = "DamageStatsBoost", menuName = "StatsBoost/DamageStatsBoost")]
public class DamageStatsBoost : StatsBoost
{
    private PlayerStats playerStats;
    public override void Apply(PlayerStats playerStats, float valueBoost)
    {
        playerStats.damage += valueBoost;
    }

    public override void Remove(PlayerStats playerStats, float valueBoost)
    {
        playerStats.damage -= valueBoost;
    }
}
