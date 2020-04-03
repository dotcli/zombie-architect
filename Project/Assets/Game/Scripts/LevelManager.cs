using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public GameObject ui;
	public Animator cameraAnimator;
	public GameObject block;
	public int blockAmount = 10;

	public Transform spawnPointA;
	public Transform spawnPointB;
	public Text scoreA;
	public Text scoreB;
	int scoreValueA = 0;
	int scoreValueB = 0;

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
    // return a random place inside the non-goal area
	Vector3 getRandomSpawnLocation() {
		return new Vector3(Random.Range(-15.0f, 15.0f), 1.0f, Random.Range(-15.0f, 15.0f));
	}
	Vector3 getRandomVectorSmall() {
		return new Vector3(Random.Range(-5.0f, 5.0f), 1.0f, Random.Range(-5.0f, 5.0f));
	}
	public void startGame() {
		// toggles on the canvas
		ui.SetActive(true);
		// rotates the camera
		cameraAnimator.SetTrigger("Start");
	}
	// respawns a fallen agent
	public void respawnAgentA(GameObject agent) {
		agent.transform.localPosition = spawnPointA.localPosition + getRandomVectorSmall();
		ZomboxAgent ag = agent.GetComponent<ZomboxAgent>();
		ag.resetVelocity();
	}
	public void respawnAgentB(GameObject agent) {
		agent.transform.localPosition = spawnPointB.localPosition + getRandomVectorSmall();
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
		scoreValueA += 1;
		scoreA.text = scoreValueA.ToString();
	}
	public void registerGoalB() {
		// TODO: increment score of B by 1
		Debug.Log("B Score!");
		scoreValueB += 1;
		scoreB.text = scoreValueB.ToString();
	}
}
