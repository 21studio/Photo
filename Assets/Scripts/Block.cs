using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public Vector2 speedMinMax;
	float speed;

	public Renderer blockRend;

	// Use this for initialization
	void Start () {
		blockRend = GetComponent<Renderer>();

		speed = Mathf.Lerp (speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (Vector3.up * speed * Time.deltaTime, Space.World); // Space.Self
	}
}
