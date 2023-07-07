using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossController : MonoBehaviour
{
    //public bool isAttacking;
    public float attack;
    public float health;
    public float MaxHealth;
    private float viewRadius = 30.0f;
    private LayerMask playerMask;
    public bool isAlive = true;
    private float speed = 4.5f;

    public float attackTime = 3.0f;
    public float coolDown = 0.5f;

    public Vector3 pos;

    private GameObject player;
    public GameObject[] attackProjectiles;

    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        playerMask = LayerMask.GetMask("Player");

        IntialiseStateMachine();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void IntialiseStateMachine()
    {
        Dictionary<Type, BaseState> states = new Dictionary<Type, BaseState>();

        states.Add(typeof(RoamState), new RoamState(this));
        states.Add(typeof(AttackState), new AttackState(this));
        states.Add(typeof(ChaseState), new ChaseState(this));

        GetComponent<FiniteStateMachine>().SetStates(states);
    }

    public void Attack()
    {
        Debug.Log("Boss Attack");
        Instantiate(attackProjectiles[0], new Vector3(transform.position.x, 0.5f, transform.position.z), Quaternion.Euler(transform.rotation.x, GenerateAttackAngle(), transform.rotation.z));
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return MaxHealth;
    }

    //public bool CheckAttacking()
    //{
    //    //return isAttacking;
    //}

    public void MoveToPoint(Vector3 pos)
    {
        transform.LookAt(pos);
        GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * (speed * Time.deltaTime));
        //GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse);
        Debug.Log("Moving Boss to Position");
    }

    public void LookAt(Vector3 pos)
    {
        transform.LookAt(pos);
    }

    public GameObject targetPos()
    {
        return player.gameObject;
    }

    public bool InAttackRange()
    {
        Collider[] view = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

        for (int i = 0; i < view.Length; i++)
        {
            GameObject target = view[i].gameObject;

            if (target.tag == "Player")
            {
                player = view[i].gameObject;
                return true;
            }
        }

        return false;
    }
    public Vector3 GenerateMovePosition()
    {
        float xPos = UnityEngine.Random.Range(transform.position.x - 15.0f, transform.position.x + 15.0f);
        float zPos = UnityEngine.Random.Range(transform.position.z - 15.0f, transform.position.z + 15.0f);

        Debug.Log("Generating Move Position");

        return new Vector3(xPos, 1, zPos);
    }

    public void CheckAlive()
    {
        if (health <= 0)
        {
            isAlive = false;

        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private float GenerateAttackAngle()
    {
        float angle = UnityEngine.Random.Range(0, 360);

        return angle;
    }
}
