using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStats", menuName = "CharacterStats")]
public class CharacterStats : ScriptableObject
{
    [SerializeField] private PlayerStats playerStats;

    [SerializeField] private int money;
    [SerializeField] private int key;
    [SerializeField] private int bomb;

    public bool IsCanFly { get { return playerStats.isCanFly; } set { playerStats.isCanFly = value; } }
    public float Speed { get { return playerStats.speed; } }
    public float Damage { get { return playerStats.damage; } }
    public float TearsPerSecend { get { return playerStats.tearsPerSecend; } }
    public float DamageMultiplier { get { return playerStats.damageMultiplier; } }
    public float Range { get { return playerStats.range; } }
    public int Luck { get { return playerStats.luck; } }


    public int Money { get { return money; } }
    public int Key { get { return key; } }
    public int Bomb { get { return bomb; } }
}
