//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;
//using UnityEngine;

//public class PassiveAbility : MonoBehaviour
//{
//    public Image icon;
//    private PlayerController player;

//    public float baseCastTime;
//    public float castTime;
//    public float level;
//    public float maxLevel;

//    public float stat;
//    // Start is called before the first frame update
//    void Start()
//    {
       
//    }

//    private void Awake()
//    {
       
//    }

//    public void Instantiate()
//    {
//        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
//        level = 1;
//    }

//    public void Ability()
//    {
//        Debug.Log("Ability activated");

//        switch(stat)
//        {
//            case 1:


//                if(castTime <= 0)
//                {
//                    player.Heal(1);
//                    castTime = baseCastTime;
//                }
//                else
//                {
//                    castTime -= Time.deltaTime;
//                }


//                break;

//            case 2:

//                if(player.attackBoosted)
//                {
//                    castTime -= Time.deltaTime;

//                    break;
//                }
//                else if(player.attackTime <= -3)
//                {
//                    player.playerDamage += player.playerDamage * 0.2f;

//                    break;
//                }
//                else
//                {
//                    castTime -= Time.deltaTime;
//                }

//                break;

//            case 3:

//                if (player.speedBoosted)
//                {
//                    castTime -= Time.deltaTime;

//                    break;
//                }
//                else if (castTime <= -3)
//                {
//                    player.speed += player.speed * 0.2f;

//                    break;
//                }
//                else
//                {
//                    castTime -= Time.deltaTime;
//                }

//                break;
//        }
//    }

//    public void LevelUp()
//    {
//        if (level < maxLevel)
//        {
//            level = level + 1;
//            castTime = castTime * 0.8f;
//        }

//    }
//    float Heal()
//    {
//        switch (level)
//        {
//            case 1:

//                if (player.playerHealth < player.MaxHealth)
//                {
//                    return player.playerHealth * 0.25f;
//                }

//                break;

//            case 2:

//                if (player.playerHealth < player.MaxHealth)
//                {
//                    return player.playerHealth * 0.3f;

//                }

//                break;

//            case 3:

//                if (player.playerHealth < player.MaxHealth)
//                {
//                    return player.playerHealth * 0.35f;

//                }

//                break;

//            case 4:

//                if (player.playerHealth < player.MaxHealth)
//                {
//                    return player.playerHealth * 0.4f;

//                }

//                break;

//            case 5:

//                if (player.playerHealth < player.MaxHealth)
//                {
//                    return player.playerHealth * 0.45f;

//                }

//                break;
//        }

//        return 0;
//    }
//}
