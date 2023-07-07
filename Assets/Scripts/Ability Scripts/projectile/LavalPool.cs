using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavalPool : MonoBehaviour
{
    //public Vector3 direction;
    public float scaleRate = 1.0f;
    public float attack;
    private PlayerController player;
    private float activeTime = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        Physics.IgnoreLayerCollision(8, 8);
        Physics.IgnoreLayerCollision(8, 11);
    }

    // Update is called once per frame
    void Update()
    {
        if(scaleRate <= 0.0f)
        {
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * 1.2f, gameObject.transform.localScale.y, gameObject.transform.localScale.z * 1.2f);
            scaleRate = 1.0f;
        }

        if (activeTime <= 0)
        {
            Destroy(gameObject);
        }

        activeTime -= Time.deltaTime;
        scaleRate -= Time.deltaTime;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy" && player != null)
        {
            float damage = attack + player.playerDamage;

            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);

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
