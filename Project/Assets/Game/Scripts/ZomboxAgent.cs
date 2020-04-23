using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class ZomboxAgent : Agent
{
    /// <summary>
    /// The area bounds.
    /// </summary>
	[HideInInspector]
    public Bounds areaBounds;


    Rigidbody agentRB;  //cached on initialization
    
    public override void Initialize()
    {
        // Cache the agent rigidbody
        agentRB = GetComponent<Rigidbody>();

        resetVelocity();
    }

    /// <summary>
    /// Moves the agent according to the selected action.
    /// </summary>
	public void MoveAgent(float[] act)
    {

        Vector3 dirToGo = Vector3.zero;
        Vector3 rotateDir = Vector3.zero;

        int action = Mathf.FloorToInt(act[0]);

        switch (action)
        {
            case 1:
                dirToGo = transform.forward * 1f;
                break;
            case 2:
                dirToGo = transform.forward * -1f;
                break;
            case 3:
                rotateDir = transform.up * 1f;
                break;
            case 4:
                rotateDir = transform.up * -1f;
                break;
            default:
                break;
        }
        transform.Rotate(rotateDir, Time.fixedDeltaTime * 200f);
        agentRB.AddForce(dirToGo * 2f,
                         ForceMode.VelocityChange);

    }

    public override float[] Heuristic()
    {
        if (Input.GetKey(KeyCode.W))
        {
            return new float[] { 1 };
        }
        if (Input.GetKey(KeyCode.S))
        {
            return new float[] { 2 };
        }
        if (Input.GetKey(KeyCode.D))
        {
            return new float[] { 3 };
        }
        if (Input.GetKey(KeyCode.A))
        {
            return new float[] { 4 };
        }
    
        return new float[] { 0 };
    }

    /// <summary>
    /// Called every step of the engine. Here the agent takes an action.
    /// </summary>
	public override void OnActionReceived(float[] vectorAction)
    {
        // Move the agent using the action.
        MoveAgent(vectorAction);
    }

    public void resetVelocity() {
        agentRB.velocity = Vector3.zero;
        agentRB.angularVelocity = Vector3.zero;
    }
}
