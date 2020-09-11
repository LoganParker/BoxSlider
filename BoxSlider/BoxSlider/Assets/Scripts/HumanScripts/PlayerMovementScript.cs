using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody rb;
    public float sidewaysForce = 500f;
    private void FixedUpdate() {
        

        if(Input.GetKey("d")){
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }
        if(Input.GetKey("a")){
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
        }
        if(rb.position.y <-.01f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    
}
