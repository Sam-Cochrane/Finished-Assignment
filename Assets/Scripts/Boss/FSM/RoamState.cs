using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamState : BaseState
{
    private BossController boss;

    public RoamState(BossController boss)
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
        Debug.Log("Boss Roam");


        if (boss.InAttackRange())
        {
            if (Vector3.Distance(boss.transform.position, boss.targetPos().transform.position) < 20)
            {
                return typeof(ChaseState);
            }
        }
        else
        {
            Debug.Log("About to move");
            boss.MoveToPoint(boss.GenerateMovePosition());
        }

        return null;
    }
}
