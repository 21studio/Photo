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
		// Spawn a cool effect
		// Instantiate(pickupEffect, transform.position, transform.rotation);
		
		// Apply effect to the player
		//player.transform.localScale *= multiplier;
		
		//player.GetComponent<HealthBar>().maxHitpoint *= multiplier;
		//Debug.Log(player.GetComponent<HealthBar>().hitpoint);
		//Debug.Log(player.GetComponent<HealthBar>().maxHitpoint);
		
		player.GetComponent<PlayerController>().speed *= multiplier;
		Debug.Log(player.GetComponent<PlayerController>().speed);

		GetComponent<MeshRenderer>().enabled = false;
		GetComponent<Collider>().enabled = false;

		yield return new WaitForSeconds(duration);
		//player.transform.localScale = new Vector3(1,1,1);

		player.GetComponent<PlayerController>().speed /= multiplier;
		Debug.Log(player.GetComponent<PlayerController>().speed);

		//player.GetComponent<HealthBar>().maxHitpoint /= multiplier;
		//Debug.Log(player.GetComponent<HealthBar>().hitpoint);
		//Debug.Log(player.GetComponent<HealthBar>().maxHitpoint);

		Destroy(gameObject);
	}
}
