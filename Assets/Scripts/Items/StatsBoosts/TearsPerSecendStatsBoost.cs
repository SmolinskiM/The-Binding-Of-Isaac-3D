using UnityEngine;

[CreateAssetMenu(fileName = "TearsPerSecendBoostStatsBoost", menuName = "StatsBoost/TearsPerSecendBoostStatsBoost")]
public class TearsPerSecendStatsBoost : StatsBoost
{
    public override void Apply(PlayerStats playerStats, float valueBoost)
    {
        playerStats.tearsPerSecend += valueBoost;
    }

    public override void Remove(PlayerStats playerStats, float valueBoost)
    {
        playerStats.tearsPerSecend -= valueBoost;
    }
}