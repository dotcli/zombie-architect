﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoalA : MonoBehaviour {
	LevelManager _Level;
	void Awake() {
		_Level = FindObjectOfType<LevelManager>();
	}
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "block") {
			_Level.registerGoalA();
		}
	}
}