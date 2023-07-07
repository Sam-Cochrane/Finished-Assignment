using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Entity
{
    public float moveSpeed = 5f; //Speed the enemy moves by
    public float enemyMaxHealth = 20.0f;
    public float enemyHealth = 20;
    public float enemyDamage = 10;
    public float enemyXPValue = 10;
    public float damageCooldown = 0.5f;
    private float timeBetweenAttacks = 1.0f;
    public AudioClip deathSound;
    public float volume = 1;

    private GameObject player;
    private GameManage enemy;

   // private Vector3 movement; //Vector to keep track of movement of the enemy

   // public Camera cam;
    // Start is called before the first frame update
    void Start()
    {  
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player");
        }

        enemy = GameObject.FindGameObjectWithTag("Manage").GetComponent<GameManage>();

        LevelUp();

        enemyHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        damageCooldown -= Time.deltaTime;
    }

    //Function that moves the enemy 
    private void FixedUpdate()
    {     
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            transform.LookAt(player.transform.position);
            GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * (moveSpeed * Time.deltaTime));
        }

        CheckAlive();
    }

    public void OnCollisionEnter(Collision collision)
    {

        //Checks to see what it collided with to see if it should be destroyed
        if (collision.collider.tag == "Attack")
        {

            //Damages the enemy's health
            enemyHealth -= collision.gameObject.GetComponent<PlayerController>().playerDamage;

            //Check if dead and if so adds experience points to the player
           
        }

        if (collision.collider.tag == "Player")
        {
            Debug.Log("Collided with player");
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(enemyDamage);
        }


    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player" && timeBetweenAttacks <= 0.0f)           
        {
             collision.gameObject.GetComponent<PlayerController>().TakeDamage(enemyDamage);
             timeBetweenAttacks = 1.0f;              
        }
        else if(collision.collider.tag == "Player")
        {
            timeBetweenAttacks -= Time.deltaTime;
        }       
    }

    public void TakeDamage(float damage)
    {

        if(damageCooldown <= 0)
        {
            enemyHealth = enemyHealth - damage;
            damageCooldown = 0.5f;
        }

    }

    public void CheckAlive()
    {
        if (enemyHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position, volume);
            Destroy(gameObject);
            player.GetComponent<PlayerController>().gainExperience(enemyXPValue);
            player.GetComponent<PlayerController>().kills++;
            int i = Random.Range(0, 5);

            if (i >= 4)
            {
                Instantiate(enemy.GenerateEnemyDrop(), gameObject.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            }
        }
    }

    public void LevelUp()
    {
        enemyMaxHealth *= 1 + player.GetComponent<PlayerController>().playerLevel / 10;

        enemyDamage *= player.GetComponent<PlayerController>().playerLevel / 10;

        enemyXPValue *= player.GetComponent<PlayerController>().playerLevel / 10;
    }

    public void OnMouseDown()
    {
        Debug.Log("Enemy Clicked");
    }
}
