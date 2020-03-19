using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class TrainingControl : MonoBehaviour {

	bool recordExperiences;
	bool resetBuffer;
	Agent myAgent;
	LevelManager _Level;
	string tag;
	GameObject[] matchingAgents;
	float bufferResetTime;

	public GameObject trainDisplay;
	public Animator wipeAnimator;
	public KeyCode recordKey = KeyCode.E;
	public KeyCode resetKey = KeyCode.R;
	public KeyCode killKey = KeyCode.Q;
	void Awake() {
		_Level = FindObjectOfType<LevelManager>();
	}
	// Use this for initialization
	void Start () {
		recordExperiences = false;
		resetBuffer = false;
		myAgent = GetComponent<Agent>();
		bufferResetTime = Time.time;
		trainDisplay.SetActive(recordExperiences);

		tag = this.gameObject.tag;
		matchingAgents = GameObject.FindGameObjectsWithTag(tag);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(recordKey))
			{
				recordExperiences = !recordExperiences;
				trainDisplay.SetActive(recordExperiences);
			}

		if (Input.GetKeyDown(resetKey))
		{
			resetBuffer = true;
			bufferResetTime = Time.time;
			// wipeAnimator.SetTrigger("wipe");
			wipeAnimator.Play("memoryWipe", 0, 0.0f);
		}
		else
		{
			resetBuffer = false;
		}

		if (Input.GetKeyDown(killKey)) {
			// XXX: shitty code by shitty programmer
			if (tag == "agentA") {
				foreach (GameObject agent in matchingAgents)
				{
					_Level.respawnAgentA(agent);
				}
			} else if (tag == "agentB") {
				foreach (GameObject agent in matchingAgents)
				{
					_Level.respawnAgentB(agent);
				}
			}
		}

		// Debug.Log("Recording experiences " + recordKey, recordExperiences.ToString());
		// float timeSinceBufferReset = Time.time - bufferResetTime;
		// Debug.Log("Seconds since buffer reset " + resetKey, 
		// 	Mathf.FloorToInt(timeSinceBufferReset).ToString());
	}

	void FixedUpdate() {
		myAgent.SetTextObs(recordExperiences + "," + resetBuffer);
	}
}
