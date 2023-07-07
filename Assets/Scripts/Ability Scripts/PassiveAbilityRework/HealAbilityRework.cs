using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealAbilityRework : BasePassive
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

        timeUntilNextCast -= Time.deltaTime;
        if(timeUntilNextCast <= 0)
        {
            switch (level)
            {
                case 1:

                    player.health = player.health + 1;

                    Debug.Log("Heal LEVEL 1");

                    break;

                case 2:

                    player.health = player.health + 1.5f;

                    Debug.Log("Heal LEVEL 2");

                    break;

                case 3:

                    player.health = player.health + 2.0f;

                    Debug.Log("Heal LEVEL 3");

                    break;

                case 4:

                    player.health = player.health + 2.5f;

                    Debug.Log("Heal LEVEL 4");

                    break;

                case 5:

                    player.health = player.health + 3.0f;

                    Debug.Log("Heal LEVEL 5");

                    break;
            }

            timeUntilNextCast = castTime;
        }       
        
        return null;
    }

    public void LevelUp()
    {
        if(level < maxLevel)
        {
            level = level + 1;
        }
    }
}
