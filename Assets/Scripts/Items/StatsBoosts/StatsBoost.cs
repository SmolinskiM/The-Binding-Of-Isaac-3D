using UnityEngine;

public abstract class StatsBoost : ScriptableObject
{
	public abstract void Apply(PlayerStats playerStats, float valueBoost);
	public abstract void Remove(PlayerStats playerStats, float valueBoost);
}