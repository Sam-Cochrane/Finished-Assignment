using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    private BossController boss;

    public ChaseState(BossController boss)
    {
        this.boss = boss;
    }
    public override Type StateEnter()
    {
        return null;
    }

    public override Type StateExit()
    {
        return null;
    }

    public override Type StateUpdate()
    {
        Debug.Log("Chase State");

        if (boss.InAttackRange())
        {
            if (Vector3.Distance(boss.transform.position, boss.targetPos().transform.position) <= 15)
            {
                return typeof(AttackState);
            }

        }
        else
        {
            return typeof(RoamState);
        }

        return null;
    }
}
