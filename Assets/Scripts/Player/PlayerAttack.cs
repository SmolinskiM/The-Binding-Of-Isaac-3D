using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Tear tearPrefab;

    private float tearCooldownLeft;

    private Player player;
    private ObjectPooling<Tear> objectPooling;

    private const int SHOT_TEAR_POWER = 100;

    public Action<Tear> OnTearEfectsEvent;

    public ObjectPooling<Tear> ObjectPooling { get { return objectPooling; } }
    public Player Player { get { return player; } set { player = value; } }

    void Start()
    {
        objectPooling = new ObjectPooling<Tear>(tearPrefab, transform);
    }

    void Update()
    {
        if (tearCooldownLeft > 0)
        {
            tearCooldownLeft -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootTear();
        }
    }

    private void ShootTear()
    {
        if (tearCooldownLeft > 0)
        {
            return;
        }

        Tear tear = objectPooling.Pool.Get();
        tear.SetDamage(player.CharacterStats.Damage * player.CharacterStats.DamageMultiplier);
        tear.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.forward) * player.CharacterStats.Range * SHOT_TEAR_POWER);
        OnTearEfectsEvent?.Invoke(tear);
        tearCooldownLeft = 1 / player.CharacterStats.TearsPerSecend;
    }
}
