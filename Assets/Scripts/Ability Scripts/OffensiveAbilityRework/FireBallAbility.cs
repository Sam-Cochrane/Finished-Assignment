using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class FireBallAbility : BaseAttack
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
        if(timeUntilNextCast <= 0)
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
        //AudioSource.PlayClipAtPoint(soundEffect, transform.position, volume);

        switch (level)
        {
            case 1:

                Instantiate(projectile, pos, Quaternion.Euler(0.0f, GenerateAttackAngle(), 0.0f));           

                break;

            case 2:

                Instantiate(projectile, pos, Quaternion.Euler(0.0f, GenerateAttackAngle(), 0.0f));
                Instantiate(projectile, pos, Quaternion.Euler(0.0f, GenerateAttackAngle(), 0.0f));

                break;

            case 3:

                GameObject alteredProjectile = projectile;
                alteredProjectile.transform.localScale.Set(2.0f, 2.0f, 2.0f);

                Instantiate(alteredProjectile, pos, Quaternion.Euler(0.0f, GenerateAttackAngle(), 0.0f));
                Instantiate(alteredProjectile, pos, Quaternion.Euler(0.0f, GenerateAttackAngle(), 0.0f));

                break;

            case 4:

                GameObject alteredProjectile2 = projectile;
                alteredProjectile2.transform.localScale.Set(2.0f, 2.0f, 2.0f);

                Instantiate(alteredProjectile2, pos, Quaternion.Euler(0.0f, GenerateAttackAngle(), 0.0f));
                Instantiate(alteredProjectile2, pos, Quaternion.Euler(0.0f, GenerateAttackAngle(), 0.0f));
                Instantiate(alteredProjectile2, pos, Quaternion.Euler(0.0f, GenerateAttackAngle(), 0.0f));

                break;

            case 5:

                GameObject alteredProjectile3 = projectile;
                alteredProjectile3.transform.localScale.Set(2.0f, 2.0f, 2.0f);

                Instantiate(alteredProjectile3, pos, Quaternion.Euler(0.0f, GenerateAttackAngle(), 0.0f));
                Instantiate(alteredProjectile3, pos, Quaternion.Euler(0.0f, GenerateAttackAngle(), 0.0f));
                Instantiate(alteredProjectile3, pos, Quaternion.Euler(0.0f, GenerateAttackAngle(), 0.0f));
                Instantiate(alteredProjectile3, pos, Quaternion.Euler(0.0f, GenerateAttackAngle(), 0.0f));

                break;
        }
    }


    public void LevelUp()
    {
        if(level < maxLevel)
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
}
