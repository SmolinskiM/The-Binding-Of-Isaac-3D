using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : ScriptableObject
{
    private bool isCanFly;
    private float speed;
    private float damage;
    private float tearsPerSecend;
    private float damageMultiplier;
    private float range;
    private int heartContener;
    private int heartInContener;
    private int luck;

    private int money;
    private int key;
    private int bomb;

    public bool IsCanFly { get { return isCanFly; } }
    public float Speed { get { return speed; } }
    public float Damage { get { return damage; } }
    public float TearsPerSecend { get { return tearsPerSecend; } }
    public float DamageMultiplier { get { return damageMultiplier; } }
    public float Range { get { return range; } }
    public int HeartContener { get { return heartContener; } }
    public int HeartInContener { get { return heartInContener; } }
    public int Luck { get { return luck; } }


    public int Money { get { return money; } }
    public int Key { get { return key; } }
    public int Bomb { get { return bomb; } }
}
