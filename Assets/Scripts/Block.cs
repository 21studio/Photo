using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public Vector2 speedMinMax;
	float speed;

	float visibleHeightThreshold;
	
	public Color colorStart = Color.red;
	public Color colorEnd = Color.green;
	public float duration = 5.0f;
	public Renderer blockRend;

	// Use this for initialization
	void Start () {
		blockRend = GetComponent<Renderer>();

		speed = Mathf.Lerp (speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());

		visibleHeightThreshold = Camera.main.orthographicSize + transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		//float lerp = Mathf.PingPong(Time.time, duration) / duration;
		//blockRend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
		
		transform.Translate (Vector3.up * speed * Time.deltaTime, Space.World); // Space.Self

		if (transform.position.y > visibleHeightThreshold) {
			Destroy (gameObject);
		}
	}
}
