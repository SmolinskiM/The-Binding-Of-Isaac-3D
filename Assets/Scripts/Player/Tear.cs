using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tear : MonoBehaviour
{
    private float damage;

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Player>())
        {
            return;
        }

        if(collision.gameObject.GetComponent<Monster>())
        {
            collision.gameObject.GetComponent<Monster>().HitMonster(damage);
        }

        Player.Instance.PlayerAttack.ObjectPooling.Pool.Release(this);
    }
}