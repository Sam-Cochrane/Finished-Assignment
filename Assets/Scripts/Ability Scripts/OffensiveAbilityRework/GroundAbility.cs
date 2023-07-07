using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GroundAbility : BaseAttack
{
    public GameObject projectile;
    public override Type abilityStart()
    {
        castTime = baseCastTime;
        level = baseLevel;

        return null;
    }
    // Start is called before the first frame update
    public override Type abilityUpdate()
    {
        timeUntilNextCast -= Time.deltaTime;
        if (timeUntilNextCast <= 0)
        {
            Attack(pos);
            timeUntilNextCast = castTime;
        }

        return null;
    }

    public void Attack(Vector3 pos)
    {
        if (level > maxLevel)
        {
            level = maxLevel;
            //castTime = castTime * 0.8f;
        }

        GameObject pro = projectile;

        //AudioSource.PlayClipAtPoint(soundEffect, transform.position, volume);

        switch (level)
        {
            case 1:

                Instantiate(pro,new Vector3(pos.x + GenerateAttackPos(), pos.y, pos.z + GenerateAttackPos()), Quaternion.Euler(pro.transform.eulerAngles.x, GenerateAttackAngle(), pro.transform.eulerAngles.z));

                break;

            case 2:

                pro.transform.localScale.Set(1.5f, 1.0f, 1.5f);

                Instantiate(pro, new Vector3(pos.x + GenerateAttackPos(), pos.y, pos.z + GenerateAttackPos()), Quaternion.Euler(pro.transform.eulerAngles.x, GenerateAttackAngle(), pro.transform.eulerAngles.z));

                break;

            case 3:

                pro.transform.localScale.Set(1.5f, 1.0f, 1.5f);

                Instantiate(pro, new Vector3(pos.x + GenerateAttackPos(), pos.y, pos.z + GenerateAttackPos()), Quaternion.Euler(pro.transform.eulerAngles.x, GenerateAttackAngle(), pro.transform.eulerAngles.z));
                Instantiate(pro, new Vector3(pos.x + GenerateAttackPos(), pos.y, pos.z + GenerateAttackPos()), Quaternion.Euler(pro.transform.eulerAngles.x, GenerateAttackAngle(), pro.transform.eulerAngles.z));

                break;

            case 4:

                pro.transform.localScale.Set(2.5f, 1.0f, 2.5f);

                Instantiate(pro, new Vector3(pos.x + GenerateAttackPos(), pos.y, pos.z + GenerateAttackPos()), Quaternion.Euler(pro.transform.eulerAngles.x, GenerateAttackAngle(), pro.transform.eulerAngles.z));
                Instantiate(pro, new Vector3(pos.x + GenerateAttackPos(), pos.y, pos.z + GenerateAttackPos()), Quaternion.Euler(pro.transform.eulerAngles.x, GenerateAttackAngle(), pro.transform.eulerAngles.z));

                break;

            case 5:

                pro.transform.localScale.Set(3.0f, 1.0f, 3.0f);

                Instantiate(pro, new Vector3(pos.x + GenerateAttackPos(), pos.y, pos.z + GenerateAttackPos()), Quaternion.Euler(pro.transform.eulerAngles.x, GenerateAttackAngle(), pro.transform.eulerAngles.z));
                Instantiate(pro, new Vector3(pos.x + GenerateAttackPos(), pos.y, pos.z + GenerateAttackPos()), Quaternion.Euler(pro.transform.eulerAngles.x, GenerateAttackAngle(), pro.transform.eulerAngles.z));
                Instantiate(pro, new Vector3(pos.x + GenerateAttackPos(), pos.y, pos.z + GenerateAttackPos()), Quaternion.Euler(pro.transform.eulerAngles.x, GenerateAttackAngle(), pro.transform.eulerAngles.z));
                Instantiate(pro, new Vector3(pos.x + GenerateAttackPos(), pos.y, pos.z + GenerateAttackPos()), Quaternion.Euler(pro.transform.eulerAngles.x, GenerateAttackAngle(), pro.transform.eulerAngles.z));

                break;
        }
    }


    public void LevelUp()
    {
        if (level < maxLevel)
        {
            level = level + 1;
            castTime = castTime * 0.8f;
        }
    }

    private float GenerateAttackAngle()
    {
        float angle = UnityEngine.Random.Range(0, 360);

        return angle;
    }

    private float GenerateAttackPos()
    {
        float pos = UnityEngine.Random.Range(3, 10);

        return pos;
    }
}
