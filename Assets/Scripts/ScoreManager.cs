using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text tCount;
	public Text healthText;
	public Text blockText;

	public HealthBar healthBar;
	public CameraShake cameraShake;

	//HealthSystem healthSystem = new HealthSystem(100);

	int blockCount = 0;

	void GetBlock() {
		blockCount++;
		blockText.text = blockCount.ToString();
	}

	void Start () {
		//healthBar.Setup(healthSystem);
	}
	
	void OnGUI() {
		if (GUI.Button(new Rect(20, 150, 50, 50), "D")) {
			healthBar.TakeDamage(10);
			//GetComponent<HealthBar>().TakeDamage(10); //crash!!
			//healthSystem.Damage(10);
			StartCoroutine(cameraShake.Shake(.1f, .1f));			
		}
		
		if (GUI.Button(new Rect(20, 210, 50, 50), "H")) {
			healthBar.HealDamage(10);
			//healthSystem.Heal(10);			
		}
	}

	// Update is called once per frame
	void Update () {
		scoreText.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
		tCount.text = Input.touchCount.ToString();
		healthText.text = healthBar.hitpoint.ToString();
		//healthText.text = healthSystem.GetHealth().ToString();
	}
}
