using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] public float numOfEnemies;
    [SerializeField] float numOfEnemiesUntilLevelComplete;
    [SerializeField] GameObject levelCompleter;

    public bool completed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(completed)
        {
            SceneManager.LoadScene("Level Select");
        }
    }

    void FixedUpdate()
    {
        CheckLevelStatus();
    }

    void CheckLevelStatus()
    {
        if(numOfEnemiesUntilLevelComplete == 0 || levelCompleter == null)
        {
            completed = true;
        }
    }
}
