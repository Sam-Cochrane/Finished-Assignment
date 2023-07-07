using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManage : MonoBehaviour
{

    public bool gameCompleted = false;
    public GameObject[] enemies;
    
    public GameObject[] abilities;
    public GameObject[] attackAbilities;
    public GameObject[] passiveAbilities;

    public spawnEnemy[] spawners;
    public GameObject[] enemyDrops;
    public float timeBetweenSpawns = 1.0f;
    public PlayerController player;
    public BossController boss;
    private float timeElapsed;


    // Start is called before the first frame update
    void Start()
    {
        //Stuff for object pooling
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); //Allows object to move between levels without being destroyed
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (timeBetweenSpawns <= 0)
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                int j = Random.Range(0, enemies.Length);
                spawners[i].Spawn(enemies[j]);
            }
            timeBetweenSpawns = 1;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }

        if(player.isDead)
        {
            SceneManager.LoadScene("GameOver");
            gameObject.SetActive(false);
            
        }

        if(boss.isAlive == false && boss != null)
        {
            gameCompleted = true;
            SceneManager.LoadScene("GameWin");
            gameObject.SetActive(false);
        }

        timeElapsed += Time.deltaTime;

    }

    public GameObject GenerateAbility()
    {

        int i = Random.Range(0, abilities.Length);

        if(abilities[i])
        {
            return abilities[i];
        }
        else
        {
            Debug.Log("No Object");
            return null;
        }

    }

    public GameObject GenerateAttackAbility()
    {
        int a = Random.Range(0, attackAbilities.Length);

        if (attackAbilities[a])
        {
            return attackAbilities[a];
        }
        else
        {
            return null;
        }
    }

    public GameObject GenerateEnemyDrop()
    {
        int i = Random.Range(0, enemyDrops.Length);

        if (enemyDrops[i])
        {
            return enemyDrops[i];
        }
        else
        {
            Debug.Log("No Object");
            return null;
        }

    }

    public GameObject GenerateEnemy()
    {
        int i = Random.Range(0, enemies.Length);

        if (enemies[i])
        {
            return enemies[i];
        }
        else
        {
            Debug.Log("No Object");
            return null;
        }
    }

}
