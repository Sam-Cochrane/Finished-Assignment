using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    private GameObject player;
    private GameObject manager;
    private GameObject UI;

    // Start is called before the first frame update
    void Start()
    { 
        player = GameObject.FindGameObjectWithTag("Player");
        manager = GameObject.FindGameObjectWithTag("Manage");
        UI = GameObject.FindGameObjectWithTag("UI");

        if(player)
        {
            Destroy(player);
        }

        if(manager)
        {
            Destroy(manager);
        }

        if(UI)
        {
            Destroy(UI);
        }

    }

}
