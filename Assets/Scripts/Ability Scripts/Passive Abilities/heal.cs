using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class heal : passive
{
    private float level;
    public float castTime;
    public float baseCastTime;
    public float healAmount;
    private float timeUntilNextCast;
    public Image icon;

    private PlayerController player;
    public override Type AbilityUpdate()
    {
        if (timeUntilNextCast <= 0)
        {

            player.GetComponent<PlayerController>().Heal(Heal());


            timeUntilNextCast = castTime;
        }

        timeUntilNextCast -= Time.deltaTime;

        return null;
    }

    float Heal()
    {
        switch (level)
        {
            case 1:

                if (player.playerHealth < player.MaxHealth)
                {
                    return player.playerHealth * 0.25f;
                }

                break;

            case 2:

                if (player.playerHealth < player.MaxHealth)
                {
                    return player.playerHealth * 0.3f;

                }

                break;

            case 3:

                if (player.playerHealth < player.MaxHealth)
                {
                    return player.playerHealth * 0.35f;

                }

                break;

            case 4:

                if (player.playerHealth < player.MaxHealth)
                {
                    return player.playerHealth * 0.4f;

                }

                break;

            case 5:

                if (player.playerHealth < player.MaxHealth)
                {
                    return player.playerHealth * 0.45f;

                }

                break;
        }

        return 0;
    }
}
