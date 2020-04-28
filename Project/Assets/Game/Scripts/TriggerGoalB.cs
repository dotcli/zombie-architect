using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoalB : MonoBehaviour {
	LevelManager _Level;
	void Awake() {
		_Level = FindObjectOfType<LevelManager>();
	}
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "block") {
			_Level.registerGoalB();
            // find which agent is responsible for the goal,
            // and reward them.
            ZomboxBall ball = col.gameObject.GetComponent<ZomboxBall>();
            ball.RewardAgent(ZomboxTeam.B);
            ball.Reset();
        }
	}
}
