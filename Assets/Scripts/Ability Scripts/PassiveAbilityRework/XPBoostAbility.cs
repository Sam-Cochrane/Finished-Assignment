using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class XPBoostAbility : BasePassive
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
        if(level > maxLevel)
        {
            level = maxLevel;
        }

        if (lastLevel < level)
        {
            lastLevel = level;

            switch (level)
            {
                case 1:

                    player.XPMultiplier = 1.2f;

                    Debug.Log("XP LEVEL 1");

                    break;

                case 2:

                    player.XPMultiplier = 1.4f;

                    Debug.Log("XP LEVEL 2");

                    break;

                case 3:

                    player.XPMultiplier = 1.6f;

                    Debug.Log("XP LEVEL 3");

                    break;

                case 4:

                    player.XPMultiplier = 1.8f;

                    Debug.Log("XP LEVEL 4");

                    break;

                case 5:

                    player.XPMultiplier = 2.0f;

                    Debug.Log("XP LEVEL 5");

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
