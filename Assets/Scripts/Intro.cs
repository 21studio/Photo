using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

	public void PlayGame() {
		SceneManager.LoadScene(1);
	}

	void Update() {
		if (Input.GetKeyDown("escape")) {
            	Application.Quit();
        	}
	}
}
