using UnityEngine;

[CreateAssetMenu(fileName = "DamageMultiplierStatsBoost", menuName = "StatsBoost/DamageMultiplierStatsBoost")]
public class DamageMultiplierStatsBoost : StatsBoost
{
    public override void Apply(PlayerStats playerStats, float valueBoost)
    {
        playerStats.damageMultiplier *= valueBoost;
    }

    public override void Remove(PlayerStats playerStats, float valueBoost)
    {
        playerStats.damageMultiplier /= valueBoost;
    }
}