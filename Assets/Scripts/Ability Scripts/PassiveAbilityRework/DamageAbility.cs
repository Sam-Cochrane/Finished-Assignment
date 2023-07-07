using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class DamageAbility : BasePassive
{
    public PlayerController player;
    public float lastLevel = 0;
    public override Type abilityStart()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        level = baseLevel;

        return null;
    }
    public override Type abilityUpdate()
    {
        if (level > maxLevel)
        {
            level = maxLevel;
        }

        if (lastLevel < level)
        {
            lastLevel = level;

            float damage;

            switch (level)
            {
                case 1:

                    damage = player.unBuffedDamage * 1.2f;

                    player.playerDamage = damage;

                    Debug.Log("Health LEVEL 1");

                    break;

                case 2:

                    damage = player.unBuffedDamage * 1.4f;

                    player.playerDamage = damage;

                    Debug.Log("Health LEVEL 2");

                    break;

                case 3:

                    damage = player.unBuffedDamage * 1.6f;

                    player.playerDamage = damage;

                    Debug.Log("Health LEVEL 3");

                    break;

                case 4:

                    damage = player.unBuffedDamage * 1.8f;

                    player.playerDamage = damage;

                    Debug.Log("Health LEVEL 4");

                    break;

                case 5:

                    damage = player.unBuffedDamage * 2.0f;

                    player.playerDamage = damage;

                    Debug.Log("Damage LEVEL 5");

                    break;
            }
        }

        return null;
    }

    public void LevelUp()
    {
        if (level < maxLevel)
        {
            level = level + 1;
        }
    }
}
