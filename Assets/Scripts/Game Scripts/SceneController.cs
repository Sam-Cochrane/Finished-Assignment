using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exitPressed()
    {
        Application.Quit();
    }

    public void OnCollisionEnter(Collision collision)
    {
         if(collision.collider.tag =="Player")
         {
            SceneManager.LoadScene(sceneName);
         }
    }
}
