using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    // Start is called before the first frame update
    public float money = 500;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpendMoney(float spent)
    {
        money -= spent;
    }
}
