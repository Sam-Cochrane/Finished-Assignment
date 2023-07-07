using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text health;
    [SerializeField] private TMP_Text attack;
    [SerializeField] private TMP_Text speed;
    [SerializeField] private TMP_Text xpUntilNextLevel;

    private string playerHealth;
    private string playerAttack;
    private string playerSpeed;
    private string playerXPUntilNextLevel;

    [SerializeField] private Button mainMenu;
    [SerializeField] private Button Settings;

    [SerializeField] private GameObject settingsMenu;

    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //playerHealth = health.text.ToString();
        //playerAttack = attack.text.ToString();
        //playerSpeed = speed.text.ToString();
        playerXPUntilNextLevel = xpUntilNextLevel.text.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        health.text = player.playerHealth.ToString();
        attack.text = player.playerDamage.ToString();
        speed.text = player.speed.ToString();
        xpUntilNextLevel.text = player.XPUntilNextLevel.ToString();
    }

    public void ChangeScene(string scene)
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(scene);
    }

    //public void OpenSettings()
    //{
    //    settingsMenu.gameObject.SetActive(true);
    //}

    //public void CloseSettings()
    //{
    //    settingsMenu.gameObject.SetActive(false);
    //}


}
