using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : SingletoneMonobehaviour<Player>
{
    public Action OnUseItemEfectsEvent;
    public Action OnAreaDamage;

    [SerializeField] private Camera _camera;

    private HeartSystem heartSystem;
    private CharacterStats characterStats;

    private int money;
    private int key;
    private int bomb;

    private int devilRoomChange;

    private float verticalRotation = 0;

    private PlayerAttack playerAttack;

    private const float VERTICAL_ROTATION_LIMIT = 90f;

    public int Money { get { return money; } }
    public int Key { get { return key; } }
    public int Bomb { get { return bomb; } }
    public PlayerAttack PlayerAttack { get { return playerAttack; } }
    public CharacterStats CharacterStats { get { return characterStats; } }

    private new void Awake()
    {
        heartSystem = GetComponent<HeartSystem>();
        heartSystem.OnTakeDmageOnRedHeart += TakeDamageOnRedHeart;
        heartSystem.OnTakeDmageOnBlackHeart += TakeDamageOnBlackHeart;
    }

    private void Update()
    {
        Movement();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            UseUsableItem();
        }
    }

    public void SetStartStats(CharacterStats characterStats)
    {
        // player stats = character stats
        this.characterStats = characterStats;
        playerAttack.Player = this;

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
 