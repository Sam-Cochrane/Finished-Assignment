using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    // public GameObject[] enemy
    public GameObject spawnCenter;
    private void FixedUpdate()
    {

    }

    public void Spawn(GameObject enemy)
    {
        Instantiate(enemy, GenerateSpawnPoint(), Quaternion.Euler(0.0f, 0.0f, 0.0f));
    }

    public Vector3 GenerateSpawnPoint()
    {
        Vector3 origin = transform.position;
        Vector3 range = transform.localScale / 2.0f;
        Vector3 randomRange = new Vector3(Random.Range(-range.x, range.x), 0.0f, Random.Range(-range.z, range.z));
        Vector3 spawnPoint = origin + randomRange;

        return spawnPoint;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.2f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
