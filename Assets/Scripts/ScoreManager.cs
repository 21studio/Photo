using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text tCount;
	public Text healthText;
	
	public Text blockText;
	public Text spawnText;
	
	public Text timescaleText;
	public Text speedText;

	public HealthBar healthBar;
	public CameraShake cameraShake;
	
	int blockCount = 0;
	int spawnCount = 0;

	void GetBlock() {
		blockCount++;
		blockText.text = "Blocks: " + blockCount.ToString();
	}

	void SpawnBlock() {
		spawnCount++;
		spawnText.text = "Spawn: " + spawnCount.ToString();
	}

	void Start () {
		//healthBar.Setup(healthSystem);
	}
		
	void Update () {
		scoreText.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
		tCount.text = Input.touchCount.ToString();
		healthText.text = GameObject.Find("HealthBar").GetComponent<HealthBar>().hitpoint.ToString() + " / " + GameObject.Find("HealthBar").GetComponent<HealthBar>().maxHitpoint.ToString();
		//healthText.text = healthBar.hitpoint.ToString() + " / " + healthBar.maxHitpoint.ToString();
		//healthText.text = healthSystem.GetHealth().ToString();
		timescaleText.text = "TimeScale: " + Time.timeScale.ToString("N2");
		speedText.text = "Speed: " + GameObject.Find("Player").GetComponent<PlayerController>().speed.ToString();
	}
}
