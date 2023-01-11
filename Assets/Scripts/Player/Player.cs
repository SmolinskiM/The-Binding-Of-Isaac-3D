using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : SingletoneMonobehaviour<Player>
{
    [SerializeField] private Tear tearPrefab;
    [SerializeField] private Camera _camera;

    [SerializeField] private CharacterStats characterStats;

    private HeartSystem heartSystem;

    private float tearCooldownLeft;

    private int money;
    private int key;
    private int bomb;

    private int devilRoomChange;

    private float verticalRotation = 0;
    
    private ObjectPooling<Tear> objectPooling;

    private const int SHOT_TEAR_POWER = 100;
    private const float VERTICAL_ROTATION_LIMIT = 90f;

    public Action OnUseItemEfectsEvent;
    public Action<Tear> OnTearEfectsEvent;
    public Action OnAreaDamage;

    public int Money { get { return money; } }
    public int Key { get { return key; } }
    public int Bomb { get { return bomb; } }
    public ObjectPooling<Tear> ObjectPooling { get { return objectPooling; } }

    private new void Awake()
    {
        heartSystem = GetComponent<HeartSystem>();
        heartSystem.OnTakeDmageOnRedHeart += TakeDamageOnRedHeart;
        heartSystem.OnTakeDmageOnBlackHeart += TakeDamageOnBlackHeart;

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
        this.characterStats = characterStats;

        money = characterStats.Money;
        key = characterStats.Key;
        bomb = characterStats.Bomb;
    }

    private void Movement()
    {
        Vector3 movementDirection = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal")) * Time.deltaTime;
        transform.Translate(movementDirection * characterStats.Speed);

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
        tear.SetDamage(characterStats.Damage * characterStats.DamageMultiplier);
        tear.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * characterStats.Range * SHOT_TEAR_POWER);
        OnTearEfectsEvent?.Invoke(tear);
        tearCooldownLeft = 1 / characterStats.TearsPerSecend;
    }

    private void UseUsableItem()
    {
        OnUseItemEfectsEvent?.Invoke();
    }

    private void ICanFly()
    {
        characterStats.IsCanFly = true;
        _camera.transform.position = new Vector3(0, 1, 0);
    }

    private void TakeDamageOnRedHeart()
    {
        devilRoomChange = 1;

        if(heartSystem.HeartsRedList[0].heartSize == HeartSize.Empty)
        {
            Die();
        }
    }

    private void TakeDamageOnBlackHeart()
    {
        OnAreaDamage?.Invoke();
        if (heartSystem.HeartsColoredList.Count == 0 && heartSystem.HeartsRedList[0].heartSize == HeartSize.Empty)
        {
            Die();
        }
    }

    private void Die()
    {
        //Display dead screen
    }    
}
 