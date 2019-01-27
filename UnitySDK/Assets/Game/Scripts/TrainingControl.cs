using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class TrainingControl : MonoBehaviour {

	bool recordExperiences;
	bool resetBuffer;
	Agent myAgent;
	float bufferResetTime;

	public GameObject trainDisplay;
	public Animator wipeAnimator;
	public KeyCode recordKey = KeyCode.E;
	public KeyCode resetKey = KeyCode.R;

	// Use this for initialization
	void Start () {
		recordExperiences = false;
		resetBuffer = false;
		myAgent = GetComponent<Agent>();
		bufferResetTime = Time.time;
		trainDisplay.SetActive(recordExperiences);
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

		// Debug.Log("Recording experiences " + recordKey, recordExperiences.ToString());
		// float timeSinceBufferReset = Time.time - bufferResetTime;
		// Debug.Log("Seconds since buffer reset " + resetKey, 
		// 	Mathf.FloorToInt(timeSinceBufferReset).ToString());
	}

	void FixedUpdate() {
		myAgent.SetTextObs(recordExperiences + "," + resetBuffer);
	}
}
