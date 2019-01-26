using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFall : MonoBehaviour {
	LevelManager _Level;
	void Awake() {
		_Level = FindObjectOfType<LevelManager>();
	}
	void OnTriggerEnter(Collider col) {
		switch (col.gameObject.tag)
		{
				case "agentA":
					_Level.respawnAgentA(col.gameObject);
					break;
				case "agentB":
					_Level.respawnAgentB(col.gameObject);
					break;
				case "block":
					_Level.respawnBlock(col.gameObject);
					break;
				default:
					Debug.Log("Oh no, a " + col.gameObject.tag + " fell.");
					break;
		}
	}

}
