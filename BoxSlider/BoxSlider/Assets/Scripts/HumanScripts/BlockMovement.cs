using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlockMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = -500f;
    private void FixedUpdate() 
    {
        rb.AddForce(0,0, (forwardForce * Time.deltaTime));
    }


}
