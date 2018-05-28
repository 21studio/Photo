using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float rotationSpeed;
	public float horizontalSpeed;
	public float verticalSpeed;
	
	public Color colorStart = Color.red;
	public Color colorEnd = Color.green;
	public float duration;
	public Renderer rend;

	public float touchSpeed;

	float screenHalfWidthInWorldUnits;

	public GameObject theDeathScreen;
	
	public float minSwipeDistY;
	public float minSwipeDistX;
	private Vector2 startPos;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		Debug.Log("start color: " + rend.material.color);

		float halfPlayerWidth = transform.localScale.x / 2f;
		screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
		}
	
	// Update is called once per frame
	void Update () {		

		/* 
		if (Input.touchCount > 0) {
			Touch touch = Input.touches[0];

			switch (touch.phase) {
				
				case TouchPhase.Began :
					startPos = touch.position;
					break;

				case TouchPhase.Ended : 
					float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
					if (swipeDistVertical > minSwipeDistY) {
						float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
						if (swipeValue > 0) {
							Debug.Log ("up swipe");
						}
						else if (swipeValue < 0) {
							Debug.Log ("down swipe");
						}

					}

					float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
					if (swipeDistHorizontal > minSwipeDistX) {
						float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
						if (swipeValue > 0) {
							transform.Translate (Vector2.right * Time.deltaTime);
							Debug.Log ("right swipe");
						}
						else if (swipeValue < 0) {
							transform.Translate (Vector2.right * Time.deltaTime);
							Debug.Log ("left swipe");
						}
					}
					break; 				
			}
		} */
		
		/* 
		float inputX = Input.GetAxisRaw ("Horizontal");
		float velocity = inputX * speed;
		transform.Translate (Vector2.right * velocity * Time.deltaTime);
		*/

		/* 
		if (Input.touchCount > 0 || Input.GetMouseButton(0)) {
			if (Input.mousePosition.x < Screen.width / 2) {
				transform.Translate(Vector2.right * -speed * Time.deltaTime);
			}
			else {
				transform.Translate(Vector2.right * speed * Time.deltaTime);
			}
		} */
		
		if (transform.position.x < -screenHalfWidthInWorldUnits) {
			transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
		}

		if (transform.position.x > screenHalfWidthInWorldUnits) {
			transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
		}

		//float xRotation = transform.localEulerAngles.x;
		//float yRotation = transform.localEulerAngles.y;
		//float xRotation = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
		//float yRotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
		
		//transform.Rotate(xRotation, -yRotation, 0, Space.World);
				
		//transform.localEulerAngles = new Vector3(xRotation,yRotation,0);

		/* 
		if (Input.GetMouseButton(0)) {
			float h = horizontalSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
			float v = verticalSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
			transform.Rotate(v, -h, 0, Space.World);
			//transform.Translate(Vector2.right * h);
		} */

		/*				
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			//transform.Translate(touchDeltaPosition.x * touchSpeed, touchDeltaPosition.y * touchSpeed, 0);
			transform.Rotate(new Vector3(touchDeltaPosition.y * touchSpeed, -touchDeltaPosition.x * touchSpeed, 0) * Time.deltaTime, Space.World); 
		} */

		if(Input.GetKey(KeyCode.Space)) {
			float lerp = Mathf.PingPong(Time.time, duration) / duration;
			rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
			//Debug.Log("now color: " + rend.material.color);
		}

		if(Input.GetKey(KeyCode.R)) {
			theDeathScreen.SetActive(true);			
		}

		if (Input.GetKeyDown("escape")) {
            	Application.Quit();
        	}

	}
}
