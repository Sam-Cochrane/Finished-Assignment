using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{

    private BossController boss;

    public AttackState(BossController boss)
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
        Debug.Log("Attack State");

        boss.attackTime -= Time.deltaTime;

        if (boss.attackTime <= 0)
        {
            boss.Attack();
            boss.attackTime = boss.coolDown;
        }

        boss.MoveToPoint(boss.targetPos().transform.position);

        if (boss.InAttackRange())
        {
            if (Vector3.Distance(boss.transform.position, boss.targetPos().transform.position) >= 20)
            {
                return typeof(ChaseState);
            }

            return null;

        }

        return null;
    }
}
