using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnExit : MonoBehaviour
{
    public float exitPosition = -2f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < exitPosition)
        {
            Destroy(gameObject);
        }        
    }
}
