using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFall : MonoBehaviour {
	LevelManager _Level;
	void Awake() {
		_Level = FindObjectOfType<LevelManager>();
	}
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "agent") {
			_Level.respawnAgent(col.gameObject);
		} else if (col.gameObject.tag == "block") {
			_Level.respawnBlock(col.gameObject);
		}
	}

}
