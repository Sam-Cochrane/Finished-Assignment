using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField] PlayerController player;

    [SerializeField] GameManage game;

    [SerializeField] public TMP_Text playerLevel;
    public Slider health;

    public static bool isPaused;

    public GameObject pauseMenu; //Menu for pausing
    public GameObject levelUpMenu;
    public GameObject startingAbilityMenu;

    public TMP_Text playerHealth;
    public TMP_Text playerDamage;
    public TMP_Text playerSpeed;
    public TMP_Text kills;

    private string level;
    private string kill;

    public List<Image> attackAbilityIcons;
    public List<Image> passiveAbilityIcons;
    public List<TMP_Text> levelNum;
    public List<TMP_Text> passiveLevelNum;

    public GameObject[] generatedAbilities;
    public GameObject[] buttons;
    public GameObject[] startingButtons;

    private bool startingAbilitngGenerated = false;
    private float playerLev;

    //Start is called before the first frame update
    void Start()
    {
        //pauseMenu.SetActive(false);
        //levelUpMenu.SetActive(false);
        kill = kills.text.ToString();
        //level = playerLevel.text.ToString();

        DontDestroyOnLoad(this);
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            SetHealth(player.GetComponent<PlayerController>().playerHealth);
        }
    }

    private void OnMouseOver()
    {

    }
    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //game = GameObject.FindGameObjectWithTag("Manage").GetComponent<GameManage>();
        //SetMaxHealth(player.GetComponent<PlayerController>().playerHealth);
        //SetHealth(player.GetComponent<PlayerController>().playerHealth);
        levelUpMenu.SetActive(false);
        pauseMenu.SetActive(false);

        Debug.Log("Scene Changed");
    }

    void Initialise()
    {
       
        
        levelUpMenu.SetActive(false);
        pauseMenu.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            game = GameObject.FindGameObjectWithTag("Manage").GetComponent<GameManage>();
            playerLev = player.GetComponent<PlayerController>().playerLevel;
            SetMaxHealth(player.GetComponent<PlayerController>().playerHealth);
            SetHealth(player.GetComponent<PlayerController>().playerHealth);
            StartingAbility();
            Initialise();        
        }

        if (playerLev != player.GetComponent<PlayerController>().playerLevel && Time.time > 1.0f)
        {
            LevelUp();
        }

        if (playerLevel.text != player.GetComponent<PlayerController>().playerLevel.ToString())
        {
            playerLevel.text = player.GetComponent<PlayerController>().playerLevel.ToString();
        }

        if (kills.text != player.GetComponent<PlayerController>().kills.ToString())
        {
            kills.text = player.GetComponent<PlayerController>().kills.ToString();
        }

        playerLev = player.GetComponent<PlayerController>().playerLevel;

        for (int i = 0; i < attackAbilityIcons.Count; i++)
        {
            if (attackAbilityIcons[i].sprite == null)
            {
                attackAbilityIcons[i].gameObject.SetActive(false);
            }
            else
            {
                attackAbilityIcons[i].gameObject.SetActive(true);
            }

        }

        for (int i = 0; i < passiveAbilityIcons.Count; i++)
        {
            if (passiveAbilityIcons[i].sprite == null)
            {
                passiveAbilityIcons[i].gameObject.SetActive(false);
            }
            else
            {
                passiveAbilityIcons[i].gameObject.SetActive(true);
            }

        }

        for (int i = 0; i < player.GetComponent<PlayerController>().attackAbilities.Count; i++)
        {
            attackAbilityIcons[i].sprite = player.GetComponent<PlayerController>().attackAbilities[i].GetComponent<BaseAttack>().icon;
            levelNum[i].text = player.GetComponent<PlayerController>().attackAbilities[i].GetComponent<BaseAttack>().level.ToString();
        }

        for (int i = 0; i < player.GetComponent<PlayerController>().passiveAbilities.Count; i++)
        {
            passiveAbilityIcons[i].sprite = player.GetComponent<PlayerController>().passiveAbilities[i].GetComponent<BasePassive>().icon;
            passiveLevelNum[i].text = player.GetComponent<PlayerController>().passiveAbilities[i].GetComponent<BasePassive>().level.ToString();
        }
    }
    public void SetMaxHealth(float Health)
    {
        health.maxValue = Health;
    }

    public void SetHealth(float Health)
    {
        health.value = Health;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        //isPaused = false;
    }

    //Pauses the game
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        // isPaused = true;
    }

    public void IncreaseHealth()
    {
        player.GetComponent<PlayerController>().MaxHealth += 10.0f;
        player.GetComponent<PlayerController>().playerHealth += 10.0f;
        player.GetComponent<PlayerController>().unBuffedHealth += 10.0f;
        health.maxValue = player.GetComponent<PlayerController>().MaxHealth;
        levelUpMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void IncreaseDamage()
    {
        player.GetComponent<PlayerController>().playerDamage += 2.0f;
        player.GetComponent<PlayerController>().unBuffedDamage += 2.0f;
        levelUpMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void IncreaseSpeed()
    {
        player.GetComponent<PlayerController>().speed += 0.5f;
        player.GetComponent<PlayerController>().unBuffedSpeed += 0.5f;
        levelUpMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void AddAbility(int obj)
    {
        bool alreadyHasAbility = false;

        switch (obj)
        {
            case 1:

                if (generatedAbilities[0].GetComponent<BaseAttack>() != null)
                {
                    for (int i = 0; i < player.GetComponent<PlayerController>().attackAbilities.Count; i++)
                    {
                        if (generatedAbilities[0].GetComponent<BaseAttack>().name == player.GetComponent<PlayerController>().attackAbilities[i].name)
                        {
                            player.GetComponent<PlayerController>().attackAbilities[i].GetComponent<BaseAttack>().level++;
                            alreadyHasAbility = true;
                            break;
                        }
                    }

                    if (alreadyHasAbility == false)
                    {
                        generatedAbilities[0].GetComponent<BaseAttack>().abilityStart();
                        player.GetComponent<PlayerController>().attackAbilities.Add(generatedAbilities[0]);
                    }
                }
                else
                {

                    if (generatedAbilities[0].GetComponent<BasePassive>() != null)
                    {
                        for (int i = 0; i < player.GetComponent<PlayerController>().passiveAbilities.Count; i++)
                        {
                            if (generatedAbilities[0].GetComponent<BasePassive>().name == player.GetComponent<PlayerController>().passiveAbilities[i].name)
                            {
                                player.GetComponent<PlayerController>().passiveAbilities[i].GetComponent<BasePassive>().level++;
                                alreadyHasAbility = true;
                                break;
                            }
                        }

                        if (alreadyHasAbility == false)
                        {
                            generatedAbilities[0].GetComponent<BasePassive>().abilityStart();
                            player.GetComponent<PlayerController>().passiveAbilities.Add(generatedAbilities[0]);
                        }
                    }
                }

                break;

            case 2:

                if (generatedAbilities[1].GetComponent<BaseAttack>() != null)
                {
                    for (int i = 0; i < player.GetComponent<PlayerController>().attackAbilities.Count; i++)
                    {
                        if (generatedAbilities[1].GetComponent<BaseAttack>().name == player.GetComponent<PlayerController>().attackAbilities[i].name)
                        {
                            player.GetComponent<PlayerController>().attackAbilities[i].GetComponent<BaseAttack>().level++;
                            alreadyHasAbility = true;
                            break;
                        }
                    }

                    if (alreadyHasAbility == false)
                    {
                        generatedAbilities[1].GetComponent<BaseAttack>().abilityStart();
                        player.GetComponent<PlayerController>().attackAbilities.Add(generatedAbilities[1]);
                    }
                }
                else
                {

                    if (generatedAbilities[1].GetComponent<BasePassive>() != null)
                    {
                        for (int i = 0; i < player.GetComponent<PlayerController>().passiveAbilities.Count; i++)
                        {
                            if (generatedAbilities[1].GetComponent<BasePassive>().name == player.GetComponent<PlayerController>().passiveAbilities[i].name)
                            {
                                player.GetComponent<PlayerController>().passiveAbilities[i].GetComponent<BasePassive>().level++;
                                alreadyHasAbility = true;
                                break;
                            }
                        }

                        if (alreadyHasAbility == false)
                        {
                            generatedAbilities[1].GetComponent<BasePassive>().abilityStart();
                            player.GetComponent<PlayerController>().passiveAbilities.Add(generatedAbilities[1]);
                        }
                    }
                }

                break;

            case 3:

                if (generatedAbilities[2].GetComponent<BaseAttack>() != null)
                {
                    for (int i = 0; i < player.GetComponent<PlayerController>().attackAbilities.Count; i++)
                    {
                        if (generatedAbilities[2].GetComponent<BaseAttack>().name == player.GetComponent<PlayerController>().attackAbilities[i].name)
                        {
                            player.GetComponent<PlayerController>().attackAbilities[i].GetComponent<BaseAttack>().level++;
                            alreadyHasAbility = true;
                            break;
                        }
                    }

                    if (alreadyHasAbility == false)
                    {
                        generatedAbilities[2].GetComponent<BaseAttack>().abilityStart();
                        player.GetComponent<PlayerController>().attackAbilities.Add(generatedAbilities[2]);
                    }
                }
                else
                {

                    if (generatedAbilities[2].GetComponent<BasePassive>() != null)
                    {
                        for (int i = 0; i < player.GetComponent<PlayerController>().passiveAbilities.Count; i++)
                        {
                            if (generatedAbilities[2].GetComponent<BasePassive>().name == player.GetComponent<PlayerController>().passiveAbilities[i].name)
                            {
                                player.GetComponent<PlayerController>().passiveAbilities[i].GetComponent<BasePassive>().level++;
                                alreadyHasAbility = true;
                                break;
                            }
                        }

                        if (alreadyHasAbility == false)
                        {
                            generatedAbilities[2].GetComponent<BasePassive>().abilityStart();
                            player.GetComponent<PlayerController>().passiveAbilities.Add(generatedAbilities[2]);
                        }
                    }
                }

                break;
        }

        if (levelUpMenu.activeInHierarchy == true)
        {

            levelUpMenu.SetActive(false);
        }
        else if (startingAbilityMenu.activeInHierarchy == true)
        {
            startingAbilityMenu.SetActive(false);
        }
        Time.timeScale = 1.0f;
    }

    private void LevelUp()
    {
        Time.timeScale = 0.0f;
        levelUpMenu.SetActive(true);
        playerHealth.text = player.GetComponent<PlayerController>().MaxHealth.ToString();
        playerDamage.text = player.GetComponent<PlayerController>().playerDamage.ToString();
        playerSpeed.text = player.GetComponent<PlayerController>().speed.ToString();

        for (int i = 0; i < buttons.Length; i++)
        {
            generatedAbilities[i] = game.GenerateAbility();

            if (generatedAbilities[i].GetComponent<BaseAttack>() != null)
            {
                buttons[i].GetComponent<Image>().sprite = generatedAbilities[i].GetComponent<BaseAttack>().icon;
            }
            else
            {
                buttons[i].GetComponent<Image>().sprite = generatedAbilities[i].GetComponent<BasePassive>().icon;
            }


        }
    }

    private void StartingAbility()
    {
        Time.timeScale = 0.0f;
        startingAbilityMenu.SetActive(true);

        for (int i = 0; i < startingButtons.Length; i++)
        {

            generatedAbilities[i] = game.GenerateAttackAbility();

            //while (checkNotGenerated(generatedAbilities[i]) == true)
            //{
            //    generatedAbilities[i] = game.GenerateAttackAbility();
            //}

            startingButtons[i].GetComponent<Image>().sprite = generatedAbilities[i].GetComponent<BaseAttack>().icon;
        }

        startingAbilitngGenerated = true;
    }

    //private bool checkNotGenerated(GameObject obj)
    //{

    //    for(int i = 0; i < generatedAbilities.Length; i++)
    //    {
    //        if(obj.GetComponent<AttackAbility>() != null)
    //        {
    //            if (generatedAbilities[i].GetComponent<AttackAbility>().name == obj.GetComponent<AttackAbility>().name)
    //            {
    //                return true;
    //            }
    //        }
    //        else if(obj.GetComponent<PassiveAbility>() != null)
    //        {
    //            if (generatedAbilities[i].GetComponent<PassiveAbility>().name == obj.GetComponent<PassiveAbility>().name)
    //            {
    //                return true;
    //            }
    //        }
    //        else
    //        {
    //            return false;
    //        }

    //    }

    //    return false;


    //}

}
