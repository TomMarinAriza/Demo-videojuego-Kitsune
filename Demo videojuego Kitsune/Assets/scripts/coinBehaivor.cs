using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class coinBehaivor : MonoBehaviour
{
        
    private void OnTriggerEnter2D(Collider2D other) 
{
    if(other.gameObject.CompareTag("Player"))
    {
        gameManager.Instance.AddPoints(1);
        Destroy(gameObject);
    }
}


    
}
