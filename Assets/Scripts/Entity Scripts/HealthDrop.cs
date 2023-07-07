using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Collided with player");

            collision.gameObject.GetComponent<PlayerController>().playerHealth += 30.0f;


            if (collision.gameObject.GetComponent<PlayerController>().playerHealth > collision.gameObject.GetComponent<PlayerController>().MaxHealth)
            {
                collision.gameObject.GetComponent<PlayerController>().playerHealth = collision.gameObject.GetComponent<PlayerController>().MaxHealth;
            }

                Destroy(gameObject);
        }
    }
}
