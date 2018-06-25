using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject blockPrefab;
	//public float secondsBetweenSpawns;
	public Vector2 secondsBetweenSpawnsMinMax;
	float nextSpawnTime;

	public Vector2 spawnSizeMinMax;
	public float spawnAngleMax;
	public Color colorStart = Color.red;
	public Color colorEnd = Color.green;
	public float duration = 1.0f;

	Vector2 screenHalfSizeWorldUnits;

	// Use this for initialization
	void Start () {
		screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpawnTime) {
			float secondsBetweenSpawns = Mathf.Lerp (secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
			//Debug.Log (secondsBetweenSpawns);
			nextSpawnTime = Time.time + secondsBetweenSpawns;
			
			float spawnAngle = Random.Range (-spawnAngleMax, spawnAngleMax);
			float spawnSize = Random.Range (spawnSizeMinMax.x, spawnSizeMinMax.y);
			Vector2 spawnPosition = new Vector2 (Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), -screenHalfSizeWorldUnits.y-spawnSize/2);
			GameObject newBlock = (GameObject)Instantiate (blockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle)); // Quaternion.identity
			newBlock.transform.localScale = Vector3.one * spawnSize;
						
			//float lerp = Mathf.PingPong(Time.time, duration) / duration;
			//newBlock.GetComponent<MeshRenderer>().material.color = Color.Lerp(colorStart, colorEnd, lerp);
			
			newBlock.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
			//Debug.Log ("color: " + newBlock.GetComponent<MeshRenderer>().material.color );

			GameObject.Find("ScoreManager").SendMessage("SpawnBlock");
		}
		
	}
}
