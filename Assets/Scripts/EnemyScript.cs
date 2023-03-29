using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    string sceneName;

    void Start() {
    sceneName = SceneManager.GetActiveScene().name;
    }

     void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Player")
        {
        
             SceneManager.LoadScene("EndPlate");
            GameManager.Instance.setCurrentScene(sceneName);
        }
        
    }
}
