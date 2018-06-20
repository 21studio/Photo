using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseMenu;

	public void PauseGame() {
		Time.timeScale = 0f;		
		pauseMenu.SetActive(true);
	}

	public void ResumeGame() {
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
	}

	public void RestartGame() {
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
		SceneManager.LoadScene (1);
	}
	
	public void QuitToMain() {
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
		pauseMenu.SetActive(false);
	}
}
