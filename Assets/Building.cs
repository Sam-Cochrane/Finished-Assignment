using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] public GameObject menu;

    public GameObject unit;
    public GameObject wallet;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(menu.activeInHierarchy == false)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }
    }

    public void SpawnEnemy()
    {
        if(wallet.GetComponent<Wallet>().money < 100)
        {

        }
        else
        {
            Instantiate(unit);
            wallet.GetComponent<Wallet>().SpendMoney(100);
        }
       
    }
}
