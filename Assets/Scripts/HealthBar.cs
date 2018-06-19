using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public Image currentHealthbar;
	public Text ratioText;	

	public float hitpoint = 100;
	private float maxHitpoint = 100;

	private void Start() {
		UpdateHealthbar();

	}

	private void UpdateHealthbar() {

		float ratio = hitpoint / maxHitpoint;
		currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
		ratioText.text = (ratio * 100).ToString("0") + '%';

	}

	public void TakeDamage(float damage) {

		hitpoint -= damage;
		if (hitpoint < 0) {
			hitpoint = 0;
			Debug.Log("Dead!");
		}
		
		//StartCoroutine(cameraShake.Shake(.1f, .1f));
		UpdateHealthbar();
	}

	public void HealDamage(float heal) {
		
		hitpoint += heal;
		
		if (hitpoint > maxHitpoint) {
			hitpoint = maxHitpoint;			
		}
		
		UpdateHealthbar();
		
	}	

	/* 
	private HealthSystem healthSystem;
	
	public void Setup (HealthSystem healthSystem) {
		this.healthSystem = healthSystem;
	}

	private void Update() {
		transform.Find("Bar").localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
	} */
}
