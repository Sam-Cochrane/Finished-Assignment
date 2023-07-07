using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : Entity
{
    //Player stats
    public float MaxHealth = 100;
    public float playerHealth = 100;
    public float unBuffedHealth = 100;
    public float unBuffedSpeed = 5;
    public float unBuffedDamage = 10;
    public float XPMultiplier = 1;

    public float playerLevel = 1;
    public float playerXP = 0;
    public float XPUntilNextLevel = 10;
    public float playerDamage = 10;
    public bool isDead = false;
    public float kills = 0;

    public bool attackBoosted = false;
    public float attackTime = 3.0f;

    //public bool speedBoosted;


    [SerializeField] public float speed = 5;
    [SerializeField] private float turnSpeed = 360;

    // public GameObject game;

    public List<GameObject> attackAbilities;

    public List<GameObject> passiveAbilities;

    public Animator animator;

    private Vector3 input;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); //Allows object to move between levels without being destroyed
    }
    private void Start()
    {


        Debug.Log(XPUntilNextLevel);

        Physics.IgnoreLayerCollision(8, 9);
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Look();

        //if(Input.GetKeyDown("e"))
        //{
        //    Attack();
        //}
    }

    void FixedUpdate()
    {
        Move();

        if (attackAbilities.Count != 0)
        {
            for (int i = 0; i < attackAbilities.Count; i++)
            {
                //attackAbilities[i].GetComponent<AttackAbility>().pos = transform.position;
                //attackAbilities[i].GetComponent<AttackAbility>().Update();
                Debug.Log("Here");
                attackAbilities[i].GetComponent<BaseAttack>().pos = transform.position;
                attackAbilities[i].GetComponent<BaseAttack>().abilityUpdate();
            }
        }

        for (int i = 0; i < passiveAbilities.Count; i++)
        {
            passiveAbilities[i].GetComponent<BasePassive>().abilityUpdate();
        }
    }

    void Move()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + (transform.forward * input.magnitude) * speed * Time.deltaTime);
    }

    void Look()
    {
        if (input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0)); //Creates offset for correct isometric movement

            var offsetInput = matrix.MultiplyPoint3x4(input);

            var relative = (transform.position + offsetInput) - transform.position;
            var rotation = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, turnSpeed * Time.deltaTime);

        }

    }

    //void Attack()
    //{
    //    animator.SetTrigger("Attack"); //Plays attack animation
    //}
    void GetInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); //Gets input for movement

    }

    public void Heal(float health)
    {
        playerHealth += health;

        if (playerHealth > MaxHealth)
        {
            playerHealth = MaxHealth;
        }
    }
    public void TakeDamage(float damage)
    {
        playerHealth -= damage; //Used to damage player when hit

        if (playerHealth <= 0)
        {
            //Destroy(gameObject);
            isDead = true;
            //gameObject.SetActive(false);
        }
    }

    public void gainExperience(float experience)
    {
        playerXP += experience * XPMultiplier;

        if (playerXP >= XPUntilNextLevel)
        {
            playerLevel++;
            playerXP = 0;
            XPUntilNextLevel = XPUntilNextLevel * 1.2f;
            Debug.Log(XPUntilNextLevel);
        }

    }


}
