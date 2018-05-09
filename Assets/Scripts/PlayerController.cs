using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float rotationSpeed;
	public float horizontalSpeed;
	public float verticalSpeed;
	public float mouseButtonSpeed;

	public Color colorStart = Color.red;
	public Color colorEnd = Color.green;
	public float duration = 1.0f;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		Debug.Log("start color: " + rend.material.color);
	}
	
	// Update is called once per frame
	void Update () {
		
		/* 
		float inputX = Input.GetAxisRaw ("Horizontal");
		float velocity = inputX * speed;
		transform.Translate (Vector2.right * velocity * Time.deltaTime);
		*/

		//float xRotation = transform.localEulerAngles.x;
		//float yRotation = transform.localEulerAngles.y;
		float xRotation = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
		float yRotation = Input.GetAxis("Horizontal") * rotationSpeed;
		
		yRotation *= Time.deltaTime;
		transform.Rotate(xRotation,-yRotation,0);
		
		//transform.localEulerAngles = new Vector3(xRotation,yRotation,0);

		/* 
		float h = horizontalSpeed * Input.GetAxis("Mouse X");
		float v = verticalSpeed * Input.GetAxis("Mouse Y");
		transform.Rotate(v, -h, 0);
		*/

		if(Input.GetMouseButton(0)) {
			transform.Rotate(new Vector3(0,mouseButtonSpeed,0) * Time.deltaTime);	
		}

		if(Input.GetMouseButton(1)) {
			transform.Rotate(new Vector3(0,-mouseButtonSpeed,0) * Time.deltaTime);	
		}

		if(Input.GetKeyDown(KeyCode.Space)) {
			//GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
			float lerp = Mathf.PingPong(Time.time, duration) / duration;
			rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
			//Debug.Log("now color: " + rend.material.color);
		}

		if(Input.GetKey(KeyCode.R)) {
			//transform.position = new Vector3(0,0,0);
			//transform.Rotate(new Vector3(0,0,0));
			transform.localEulerAngles = new Vector3(0,0,0);
			
		}
		
	}
}
