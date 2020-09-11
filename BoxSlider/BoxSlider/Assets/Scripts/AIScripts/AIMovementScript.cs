using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;
public class AIMovementScript : Agent
{
    public Rigidbody rb;
    public float sidewaysForce = 120f;
    private Quaternion initialRotation;
    private Vector3 startingPosition;
    private int score = 0;
    public float positiveReward = 1f;
    public float negativeReward = -1.0f;
    public event Action OnReset;
    
    
    public override void Initialize()
    {
        initialRotation = transform.rotation;
        startingPosition = transform.position;
    }
    public override void OnActionReceived(float[] vectorAction)
    {
        if(Mathf.FloorToInt(vectorAction[0])==1)
        {
            rb.AddForce(sidewaysForce * Time.fixedDeltaTime, 0, 0,ForceMode.VelocityChange);
        }
        if(Mathf.FloorToInt(vectorAction[1])==1)
        {
            rb.AddForce(-sidewaysForce * Time.fixedDeltaTime, 0, 0,ForceMode.VelocityChange);
        }
    }
    public override void OnEpisodeBegin()
    {
        //Reset Scene once player has lost or game has started.
        Reset();
    }
    public override void Heuristic(float[] actionsOut)
    {
        //Player Input
        actionsOut[0] = 0;
        actionsOut[1] = 0;
        
        if(Input.GetKey("d")){
            actionsOut[0]=1;
        }
        if(Input.GetKey("a")){
            actionsOut[1]=1;   
        }
    }
    private void FixedUpdate() 
    {    
        RequestDecision();
        if(rb.position.y <-.01f)
        {
            scoreHandler(false);
        }
    }
    void OnCollisionEnter(Collision other) 
    {
        if(other.collider.tag == "Obstacle"){
            scoreHandler(false);
        }
    }
    /*Handles rewards assigned to Agent based on succesful passes of the goal*/
    void scoreHandler(bool Reward)
    {
        if(Reward)
        {
            //AI has entered a score zone, give that dude a reward :) 
            //Debug.Log(GetCumulativeReward());
            score++;
            AddReward(positiveReward);
            Score.Instance.AddScore(score);
        
        }else
        {
            /*If we are assigning negative reward, 
            then the AI has failed, restart game
            */
            //Debug.Log(GetCumulativeReward());
            AddReward(negativeReward);
            EndEpisode();
        }
        
    }
    //Reset scene
    void Reset()
    {
        transform.position = startingPosition;
        transform.rotation = initialRotation;
        
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        
        score = 0;

        OnReset?.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Score"))
        {
            scoreHandler(true);
        }
    }
    
}
