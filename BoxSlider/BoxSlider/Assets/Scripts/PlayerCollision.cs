using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{   
    public PlayerMovementScript movementScript;
    public BlockSpawner spawner;
    void OnCollisionEnter(Collision other) 
    {
        if(other.collider.tag == "Obstacle"){
            movementScript.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
