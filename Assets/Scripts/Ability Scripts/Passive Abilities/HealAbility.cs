//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HealAbility : MonoBehaviour
//{
//    private float level;
//    public float castTime;
//    public float baseCastTime;
//    public float healAmount;
//    private float timeUntilNextCast;
//    private PassiveAbility ability;
//    private PlayerController player;

//    // Start is called before the first frame update
//    void Start()
//    {
//        ability = gameObject.GetComponent<PassiveAbility>();
//        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
//        timeUntilNextCast = castTime;

//        level = ability.level;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(timeUntilNextCast <= 0)
//        {

//            player.GetComponent<PlayerController>().Heal(Heal());


//            timeUntilNextCast = castTime;
//        }

//        timeUntilNextCast -= Time.deltaTime;
//        level = ability.level;
//    }

//    float Heal()
//    {
//        switch(level)
//        {
//            case 1:

//                if(player.playerHealth < player.MaxHealth)
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
