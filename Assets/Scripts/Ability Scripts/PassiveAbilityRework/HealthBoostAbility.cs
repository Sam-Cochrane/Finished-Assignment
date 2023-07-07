using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBoostAbility : BasePassive
{
    public PlayerController player;
    public float lastLevel;
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

            float health;

            switch (level)
            {
                case 1:

                    health = player.unBuffedHealth * 1.2f;

                    player.MaxHealth = health;


                    Debug.Log("Health LEVEL 1");

                    break;

                case 2:

                    health = player.unBuffedHealth * 1.4f;

                    player.MaxHealth = health;

                    Debug.Log("Health LEVEL 2");

                    break;

                case 3:

                    health = player.unBuffedHealth * 1.6f;

                    player.MaxHealth = health;

                    Debug.Log("Health LEVEL 3");

                    break;

                case 4:

                    health = player.unBuffedHealth * 1.8f;

                    player.MaxHealth = health;

                    Debug.Log("Health LEVEL 4");

                    break;

                case 5:

                    health = player.unBuffedHealth * 2.0f;

                    player.MaxHealth = health;

                    Debug.Log("Health LEVEL 5");

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
