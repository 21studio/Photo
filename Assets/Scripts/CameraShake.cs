using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	public IEnumerator Shake (float duration, float magnitude) {

		Vector3 originalPos = transform.localPosition;

		float elapsed = 0.0f;

		while (elapsed < duration) {
			
			float x = Random.Range(-0.5f, 0.5f) * magnitude;
			float y = Random.Range(-0.5f, 0.5f) * magnitude;

			transform.localPosition = new Vector3(x, y, originalPos.z);

			elapsed += Time.deltaTime;

			yield return null;
		}

		transform.localPosition = originalPos;

	}

	public void DoAction () {		
		GetComponent<Camera>().backgroundColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
		GetComponent<Camera>().transform.Rotate(new Vector3(0, 0, Random.Range(0, 180)));
						
	}
	
	public void Reset () {
		GetComponent<Camera>().backgroundColor = Color.black;
		GetComponent<Camera>().transform.rotation = Quaternion.identity;
						
	}

	public void DoBG () {
		//float rnd = Random.Range(0f, 1f);
		GameObject.Find("Bottom").GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
	}
}
