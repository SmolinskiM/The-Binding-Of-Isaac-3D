using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : SingletoneMonobehaviour<Player>
{
    public Action OnUseItemEfectsEvent;

    public Action<Tear> OnTearEfectsEvent;

    public Action<int> OnAreaDamage;

    [SerializeField] private Tear tearPrefab;
    [SerializeField] private Camera _camera;

    //stats
    private bool isCanFly;
    private float speed = 1;
    private float damage;
    private float tearsPerSecend = 10;
    private float damageMultiplier;
    private float range = 10;
    private int luck;

    // status
    private float tearCooldownLeft;

    private int money;
    private int key;
    private int bomb;

    //other
    private float verticalRotation = 0;
    
    private ObjectPooling<Tear> objectPooling;

    private const int SHOT_TEAR_POWER = 100;
    private const float VERTICAL_ROTATION_LIMIT = 90f;

    //property
    public bool IsCanFly { get { return isCanFly; } }
    public int Money { get { return money; } }
    public int Key { get { return key; } }
    public int Bomb { get { return bomb; } }
    public ObjectPooling<Tear> ObjectPooling { get { return objectPooling; } }

    private new void Awake()
    {
        objectPooling = new ObjectPooling<Tear>(tearPrefab, transform);
    }

    private void Update()
    {
        Movement();

        if(tearCooldownLeft > 0)
        {
            tearCooldownLeft -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootTear();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            UseUsableItem();
        }
    }

    public void SetStartStats(CharacterStats characterStats)
    {
        // player stats = character stats
        isCanFly = characterStats.IsCanFly;
        speed = characterStats.Speed;
        damage = characterStats.Damage;
        tearsPerSecend = characterStats.TearsPerSecend;
        damageMultiplier = characterStats.DamageMultiplier;
        luck = characterStats.Luck;

        money = characterStats.Money;
        key = characterStats.Key;
        bomb = characterStats.Bomb;
    }

    private void Movement()
    {
        Vector3 movementDirection = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal")) * Time.deltaTime;
        transform.Translate(movementDirection * speed);

        float horizontalRotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y");
        verticalRotation = Mathf.Clamp(verticalRotation , -VERTICAL_ROTATION_LIMIT, VERTICAL_ROTATION_LIMIT);
        _camera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    private void ShootTear()
    {
        if(tearCooldownLeft > 0)
        {
            return;
        }

        //Attacking
        Tear tear = objectPooling.Pool.Get();
        tear.SetDamage(damage * damageMultiplier);
        tear.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * range * SHOT_TEAR_POWER);
        OnTearEfectsEvent?.Invoke(tear);
        tearCooldownLeft = 1 / tearsPerSecend;
    }

    private void UseUsableItem()
    {
        OnUseItemEfectsEvent?.Invoke();
    }

    private void ApplyStatsBoost(StatsBoost statsBoost)
    {
        if(statsBoost.stats == Stats.SpeedUp)
        {
            speed += statsBoost.statsValue;
        }
        else if(statsBoost.stats == Stats.DamageUp)
        {
            damage += statsBoost.statsValue;
        }

        else if(statsBoost.stats == Stats.CanFly)
        {

        }
    }

    private void ICanFly()
    {
        isCanFly = true;
        _camera.transform.position = new Vector3(0, 1, 0);
    }

    private void Die()
    {
        //Display dead screen
    }    
}
 