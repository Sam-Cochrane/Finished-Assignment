using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpeedBoostAbility : BasePassive
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

            float speed;

            switch (level)
            {
                case 1:

                    speed = player.unBuffedSpeed * 1.1f;

                    player.speed = speed;

                    Debug.Log("Speed LEVEL 1");

                    break;

                case 2:

                    speed = player.unBuffedSpeed * 1.2f;

                    player.speed = speed;


                    Debug.Log("Speed LEVEL 2");

                    break;

                case 3:

                    speed = player.unBuffedSpeed * 1.3f;

                    player.speed = speed;


                    Debug.Log("Speed LEVEL 3");

                    break;

                case 4:

                    speed = player.unBuffedSpeed * 1.4f;

                    player.speed = speed;


                    Debug.Log("Speed LEVEL 4");

                    break;

                case 5:

                    speed = player.unBuffedSpeed * 1.5f;

                    player.speed = speed;


                    Debug.Log("Speed LEVEL 5");

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
