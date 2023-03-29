using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
string sceneName;

void Start(){
     sceneName = SceneManager.GetActiveScene().name;

}

    void OnCollisionEnter(Collision collision)
    {

       if (collision.gameObject.tag == "Player")
        {

            if(sceneName == "Level1"){
            
            SceneManager.LoadScene("Level1Win");
            GameManager.Instance.setCurrentScene(sceneName);
            }
            
        

        if(sceneName == "Level2"){
            
            SceneManager.LoadScene("Level2Win");
        GameManager.Instance.setCurrentScene(sceneName);
        }
            

        if(sceneName == "Level3"){
            
            SceneManager.LoadScene("GameWin");
            GameManager.Instance.setCurrentScene(sceneName);
        }
        
            
    }
}
}


