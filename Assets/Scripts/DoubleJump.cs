using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoubleJump : MonoBehaviour
{

    public GameObject particle;


    void Start() {
        gameObject.SetActive(true);
    }

   void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            GameManager.Instance.UpdateJumpText(true);
            gameObject.SetActive(false);
            Invoke(nameof(Reappear), 30f);
        }
        
    }

     public void Reappear()
    {
        
        gameObject.SetActive(true);
    }
}
