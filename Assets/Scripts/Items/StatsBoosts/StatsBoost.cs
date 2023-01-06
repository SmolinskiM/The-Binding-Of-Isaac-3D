using UnityEngine;

public abstract class StatsBoost : ScriptableObject
{
	public abstract void Apply(PlayerStats playerStats, float valueBoost);
}