using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomboxBall : MonoBehaviour
{
    public float dotThreshold = 0f;

    public ZomboxAgent ActingAgent;

    Rigidbody mRigidbody;

    float resetTimer = 0;
    public float RESET_SECONDS = 20;

    // Start is called before the first frame update
    void Start()
    {
        mRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if nobody touches the ball for 20 seconds, it respawns.
        resetTimer+= Time.deltaTime;
        if (resetTimer >= RESET_SECONDS)
        {
            Reset();
        }
    }

    // Keep track of what agent has touched the ball
    // and how they are touching it
    // !! question: do we want to consider direction?
    // if we do, we can't respond to goals that come from bouncing.
    // if we don't, it'll be difficult to distinquish between sabotagers and shooters.
    // Ok, we should.
    // But how?
    // by looking at the impulse
    // which is the counter-force that generates from a force.
    // If the reverse of impulse matches the direction of agent's velocity,
    // then that agent helped push the box into goal.
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "agentA" || collision.gameObject.tag == "agentB")
        {
            // Reset reset timer
            resetTimer = 0;
            Debug.DrawLine(
                collision.gameObject.transform.position, 
                collision.gameObject.transform.position + collision.impulse* 1f,
                Color.blue
                );
            // use normalized dot product to calculate how different the angles are
            // NOTE: For SOME reason, impulse is reversed when inferencing.
//             float dot = Vector3.Dot(-collision.impulse.normalized, mRigidbody.velocity.normalized);

            // (cont.) but in training and in manual control, it's normal.
            float dot = Vector3.Dot(collision.impulse.normalized, mRigidbody.velocity.normalized);
            // NOTE currently we only check if the agent is pushing at very roughly the same direction.
            // Ideally we want to keep track of all agents pushing the ball
            // and compare their push direction, to see who deserves reward.
            // But I'm tired and it's almost 3 so fuck it
            Debug.Log(dot);
            if (dot > dotThreshold)
            {
                Debug.Log("Found acting agent with dot: " + dot);
                ActingAgent = collision.gameObject.GetComponent<ZomboxAgent>();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        if (ActingAgent)
        {
            Gizmos.DrawSphere(ActingAgent.transform.position + Vector3.up * 1.5f, 1f);
        }
    }

    /// <summary>
    /// Reward the agents that last touched the ball
    /// </summary>
    public void RewardAgent()
    {
        if (ActingAgent)
        {
            ActingAgent.GetRewardedForGoal();
        } else
        {
            Debug.LogWarning("The ball is scored but we couldn't find an acting agent.");
        }
        
    }

    /// <summary>
    /// TODO: consider putting more stuff here in reset?
    /// </summary>
    public void Reset()
    {
        resetTimer = 0;
        // HACK ugly code: this duplicates code in LevelManager.cs
        transform.localPosition = new Vector3(Random.Range(-15.0f, 15.0f), 1.0f, Random.Range(-15.0f, 15.0f));
        mRigidbody.velocity = Vector3.zero;
        mRigidbody.angularVelocity = Vector3.zero;
        ActingAgent = null;
    }
}
