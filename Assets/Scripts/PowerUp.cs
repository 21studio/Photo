using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	//public GameObject pickupEffect;

	public float multiplier = 1.5f;
	public float duration = 5f;

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Player")) {
			StartCoroutine (Pickup(other));
		}
	}

	IEnumerator Pickup(Collider player) {
		
		// Instantiate(pickupEffect, transform.position, transform.rotation);
		
		player.transform.localScale *= multiplier;
								
		player.GetComponent<PlayerController>().speed *= multiplier;
		//Debug.Log(player.GetComponent<PlayerController>().speed);
		
		//GameObject.Find("HealthBar").GetComponent<HealthBar>().hitpoint *= multiplier;
		GameObject.Find("HealthBar").GetComponent<HealthBar>().maxHitpoint *= multiplier;
		//player.GetComponent<HealthBar>().hitpoint *= multiplier;
		
		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;

		yield return new WaitForSeconds(duration);
		
		player.transform.localScale = Vector3.one;

		player.GetComponent<PlayerController>().speed /= multiplier;
		//Debug.Log(player.GetComponent<PlayerController>().speed);

		//GameObject.Find("HealthBar").GetComponent<HealthBar>().hitpoint /= multiplier;
		GameObject.Find("HealthBar").GetComponent<HealthBar>().maxHitpoint /= multiplier;
		//player.GetComponent<HealthBar>().hitpoint /= multiplier;
		//Debug.Log(player.GetComponent<HealthBar>().hitpoint);
		//Debug.Log(player.GetComponent<HealthBar>().maxHitpoint);

		Destroy(gameObject);
	}
}
