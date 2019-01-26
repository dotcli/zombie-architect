using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public ZomboxAgent king;
	public ZomboxAgent minion;
	public GameObject block;
	public int blockAmount = 10;

	public ZomboxAgent[] agents;
	public Transform spawnPoint;
	// Use this for initialization
	void Start () {
		// spawn blocks randomly around the area
		for (int i = 0; i < blockAmount; i++)
		{
			GameObject blockClone = Instantiate(
				block,
				getRandomSpawnLocation(),
				Quaternion.identity
			);
		}
	}
	Vector3 getRandomSpawnLocation() {
		return new Vector3(Random.Range(-23.0f, 23.0f), 1.0f, Random.Range(-10.0f, 10.0f));
	}
	// respawns a fallen agent
	// TODO: respawn the agent to their faction
	public void respawnAgent(GameObject agent) {
		agent.transform.localPosition = spawnPoint.localPosition;
		ZomboxAgent ag = agent.GetComponent<ZomboxAgent>();
		ag.resetVelocity();
	}
	public void respawnBlock(GameObject block) {
		block.transform.localPosition = getRandomSpawnLocation();
		Rigidbody blockRB = block.GetComponent<Rigidbody>();
		blockRB.velocity = Vector3.zero;
		blockRB.angularVelocity = Vector3.zero;

	}
}
