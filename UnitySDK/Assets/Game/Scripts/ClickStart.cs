using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStart : MonoBehaviour {
	LevelManager _Level;
	void Awake() {
		_Level = FindObjectOfType<LevelManager>();
	}
	void OnMouseDown() {
		Debug.Log("Game start!");
		_Level.startGame();
	}
}
