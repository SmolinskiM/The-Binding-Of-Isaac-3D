using UnityEngine;

[CreateAssetMenu(fileName = "LuckStatsBoost", menuName = "StatsBoost/LuckStatsBoost")]
public class LuckStatsBoost : StatsBoost
{
    public override void Apply(PlayerStats playerStats, float valueBoost)
    {
        playerStats.luck += (int)valueBoost;
    }

    public override void Remove(PlayerStats playerStats, float valueBoost)
    {
        playerStats.luck -= (int)valueBoost;
    }
}
