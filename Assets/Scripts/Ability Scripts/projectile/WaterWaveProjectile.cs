using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaveProjectile : MonoBehaviour
{
    //public Vector3 direction;
    public float projectileSpeed;
    public float attack;
    private PlayerController player;
    private float killTime = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        Physics.IgnoreLayerCollision(8, 8);
        Physics.IgnoreLayerCollision(8, 11);

        //transform.localRotation = Quaternion.Euler(90.0f, transform.rotation.y , transform.rotation.z);

    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * (projectileSpeed * Time.deltaTime));

        killTime -= Time.deltaTime;
        if (killTime <= 0)
        {
            Destroy(this);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy" && player != null)
        {
            float damage = attack + player.playerDamage;

            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);

            Destroy(gameObject);
        }

        if (collision.collider.tag == "Boss")
        {
            if (player != null)
            {
                float damage = attack + player.playerDamage;

                collision.gameObject.GetComponent<BossController>().TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
