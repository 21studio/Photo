using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {
	
	public void RestartGame() {
		SceneManager.LoadScene (1);
	}

	public void QuitToMain() {
		//Application.LoadLevel(introLevel);
		SceneManager.LoadScene(0);
	}
}
