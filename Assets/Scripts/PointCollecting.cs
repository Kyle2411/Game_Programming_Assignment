using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollecting : MonoBehaviour
{

public GameObject particle;
    void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Player")
        {

            Instantiate(particle, transform.position, Quaternion.identity);
            
            GameManager.Instance.UpdateScore(50);
        
            Destroy(gameObject);
        }
        
    }
}
