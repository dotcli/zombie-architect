using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public ZomboxAgent king;
	public GameObject block;
	public int blockAmount = 10;

	public Transform spawnPointA;
	public Transform spawnPointB;
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
	public void respawnAgentA(GameObject agent) {
		agent.transform.localPosition = spawnPointA.localPosition;
		ZomboxAgent ag = agent.GetComponent<ZomboxAgent>();
		ag.resetVelocity();
	}
	public void respawnAgentB(GameObject agent) {
		agent.transform.localPosition = spawnPointB.localPosition;
		ZomboxAgent ag = agent.GetComponent<ZomboxAgent>();
		ag.resetVelocity();
	}
	public void respawnBlock(GameObject block) {
		block.transform.localPosition = getRandomSpawnLocation();
		Rigidbody blockRB = block.GetComponent<Rigidbody>();
		blockRB.velocity = Vector3.zero;
		blockRB.angularVelocity = Vector3.zero;
	}
	public void registerGoalA() {
		// TODO: increment score of A by 1
		Debug.Log("A Score!");
	}
	public void registerGoalB() {
		// TODO: increment score of B by 1
		Debug.Log("B Score!");
	}
}
