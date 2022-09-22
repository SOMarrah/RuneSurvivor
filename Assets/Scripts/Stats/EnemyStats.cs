using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharStats
{
    public override void Die()
    {
        base.Die();
        //add death anim/ragdoll
        Destroy(gameObject);
    }
}
