using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAgain : MonoBehaviour
{
    
    [SerializeField] GameObject Restart;
    //[SerializeField] private Transform Player;
    //[SerializeField] private Transform RespawnPoint;


    private void OnTriggerEnter(Collider other)
    {

     

        if (other.gameObject.CompareTag("Player"))
        {
           other.gameObject.transform.position = Restart.transform.position;
           other.gameObject.transform.rotation = Quaternion.identity;
           // Player.transform.position = RespawnPoint.transform.position;
           // Player.transform.rotation = Quaternion.identity;
        }
        
    }
}
