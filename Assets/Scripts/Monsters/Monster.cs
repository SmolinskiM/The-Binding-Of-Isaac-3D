using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private float health;

    public void HitMonster(float damage)
    {
        health -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(health > 0)
        {
            return;
        }

        DropLoot();
        // Return to pool
    }

    private void DropLoot()
    {

    }
}
