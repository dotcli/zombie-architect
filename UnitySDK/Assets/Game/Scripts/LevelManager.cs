using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public ZomboxAgent king;
	public ZomboxAgent minion;
	public GameObject block;
	public int blockAmount = 10;

	public ZomboxAgent[] agents;
	// Use this for initialization
	void Start () {
		// spawn blocks randomly around the area
		for (int i = 0; i < blockAmount; i++)
		{
			GameObject blockClone = Instantiate(
				block,
				new Vector3(Random.Range(-23.0f, 23.0f), 1.0f, Random.Range(-10.0f, 10.0f)),
				Quaternion.identity
			);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// rewards the agents when a block makes it to the goal
	public void rewardAgents () {

	}
}
