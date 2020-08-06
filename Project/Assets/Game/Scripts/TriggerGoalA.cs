using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoalA : MonoBehaviour {
	LevelManager _Level;
	public List<ZomboxAgent> teamA = new List<ZomboxAgent>();
	public List<ZomboxAgent> teamB = new List<ZomboxAgent>();
	
	void Awake() {
		_Level = FindObjectOfType<LevelManager>();
		GameObject[] arrAgentObjA = GameObject.FindGameObjectsWithTag("agentA");
		foreach (GameObject agentObj in arrAgentObjA)
		{
			ZomboxAgent agentScript = agentObj.GetComponent<ZomboxAgent>();
			teamA.Add(agentScript);
		}

		GameObject[] arrAgentObjB = GameObject.FindGameObjectsWithTag("agentB");
		foreach (GameObject agentObj in arrAgentObjB)
		{
			ZomboxAgent agentScript = agentObj.GetComponent<ZomboxAgent>();
			teamB.Add(agentScript);
		}
	}
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "block") {
			_Level.registerGoalA();
			// reward the team
			foreach (ZomboxAgent agent in teamA)
			{
				agent.GetRewardedForGoal(ZomboxTeam.A);
			}
			// punish the other team
			foreach (ZomboxAgent agent in teamB)
			{
				agent.GetRewardedForGoal(ZomboxTeam.A);
			}
			
			
			ZomboxBall ball = col.gameObject.GetComponent<ZomboxBall>();
			// find which agent is responsible for the goal,
			// and reward them.
			// ball.RewardAgent(ZomboxTeam.A);
			ball.Reset();
			
		}
	}
}
