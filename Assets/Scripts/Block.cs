using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public Vector2 speedMinMax;
	float speed;

	float visibleHeightThreshold;
	
	public Color colorStart = Color.black;
	public Color colorEnd = Color.clear;
	public float duration = 5.0f;
	public Renderer blockRend;
	
	void Start () {
		blockRend = GetComponent<Renderer>();

		speed = Mathf.Lerp (speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());

		visibleHeightThreshold = Camera.main.orthographicSize + transform.localScale.y;
	}
	
	void Rotate () {
		transform.Rotate(new Vector3(0, 0, 60) * Time.deltaTime);
	}

	void Translate () {
		transform.Translate (Vector3.up * speed * Time.deltaTime, Space.World); // Space.Self
	}

	void Scale () {
		Vector3 originalScale = transform.localScale;
		float scaleSize = 1.01f;
		//transform.localScale = originalScale * scaleSize;
		transform.localScale = new Vector3(Mathf.PingPong(Time.time, 1f), transform.localScale.y, transform.localScale.z);
			
	}

	void Update () {
		//float lerp = Mathf.PingPong(Time.time, duration) / duration;
		//blockRend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
		
		Rotate();
		Translate();
		//Scale();

		/* 		
		float enableX = Random.Range(3f, 15f);
		Destroy (gameObject, enableX);

		float enableX = Mathf.PingPong(1,2);
		float enableX = Mathf.PingPong(Time.time, duration) / duration;
		
		if (enableX == 1) {
			GetComponent<MeshRenderer>().enabled = false;			
		} */
		
		if (transform.position.y > visibleHeightThreshold) {
			Destroy (gameObject);
		}
	}
}
