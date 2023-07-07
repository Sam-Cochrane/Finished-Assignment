using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBall : MonoBehaviour
{
    //public Vector3 direction;
    public float projectileSpeed;
    public float attack;
    private BossController boss;
    private float killTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();

        Physics.IgnoreLayerCollision(13, 12);
        //Physics.IgnoreLayerCollision(8, 11);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * (projectileSpeed * Time.deltaTime));
        //GetComponent<Rigidbody>().AddForce(transform.position * projectileSpeed, ForceMode.Impulse);

        killTime -= Time.deltaTime;
        if(killTime <= 0)
        {
            Destroy(this);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Player")
        {
            if (boss != null)
            { 

                collision.gameObject.GetComponent<PlayerController>().TakeDamage(attack);
            }

            Destroy(gameObject);
        }
    }
}
