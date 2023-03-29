using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
     
    private static GameManager instance;
    public static int check = 0;
    public static string currentScene;
    public static int score;
    public Text ScoreText;
    public Text TotalScoreText;
    public Text jumpText;
    public static int temp;
    public string endScene;

    public static GameManager Instance {

        get {
            if(instance==null) {
                instance = new GameManager();
            }
 
            return instance;
        }
    }
    
    void Awake()
    {


        DontDestroyOnLoad(gameObject);
        endScene = SceneManager.GetActiveScene().name;

        if(check == 0){
            
            temp = score;
            check++;
        }
        
        instance = this;

        if(TotalScoreText != null){ 
            Debug.Log(currentScene);
            if(currentScene == "Level1"){
                
                TotalScore(1);
                check = 0;
        }

        if(currentScene == "Level2"){
                TotalScore(2);
                check = 0;
        }

        if(currentScene == "Level3"){
                TotalScore(3);
                check = 0;
        }
        }

        if(ScoreText != null){ 
            ScoreText.text = "Score: " + score;
        }
    }



    
    public void UpdateScore(int value)
    {
        score += value;
        ScoreText.text = "Score: " + score;
       
    }

    public void TotalScore(int option)
    {

        switch(option) {
            case 1:
            
                TotalScoreText.text = "Level 1 Score: " + score;
                break;
            case 2:
                TotalScoreText.text = "Level 2 Score: " + score;
                break;
            case 3:
                TotalScoreText.text = "Your Total Score: " + score;
                break;

    
        }
        
       
    }

    public void ResetScore()
    {
        
        if(endScene == "GameWin"){
            score = 0;
        }
        else{
            score = temp;
        }
       
       
    }

    public void setCurrentScene(string current)
    {
        currentScene = current;
       
    }

    public string getCurrentScene()
    {
        return currentScene;
       
    }

    public void UpdateJumpText(bool check)
    {

    if(check){

        jumpText.text = "Double Jump Activated!";
    }
    else{
        jumpText.text = " ";
    }
       
    }
   
}
