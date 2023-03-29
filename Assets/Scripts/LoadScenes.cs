using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    string sceneName;
    string currentScene;

    void Start()
    {
        

    }

    void Update()
    {
        
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadExit()
    {
        Application.Quit();
    }

     public void MainMenu()
    {
        GameManager.Instance.ResetScore();
       SceneManager.LoadScene("MainMenu");
    }

    public void LoadRestart()
    {
        GameManager.Instance.ResetScore();

        currentScene = GameManager.Instance.getCurrentScene();

        
         if(currentScene == "Level1"){
            
            SceneManager.LoadScene("Level1");
         }

        if(currentScene == "Level2"){
            
            SceneManager.LoadScene("Level2");

        }

        if(currentScene == "Level3"){
            
            SceneManager.LoadScene("Level3");

        }
            
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
}
