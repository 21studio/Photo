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

	GameObject gObj = null;
	Plane objPlane;
	Vector3 mO;

	public CameraShake cameraShake;
	public TimeManager timeManager;

	Ray GenerateMouseRay() {
		//Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//Debug.DrawRay(mousePos, Camera.main.transform.forward*1000, Color.green);

		Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
		Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
		Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
		Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);
		Debug.DrawRay(mousePosN, mousePosF-mousePosN, Color.green);

		Ray mr = new Ray(mousePosN, mousePosF-mousePosN);
		return mr;
	}
	
	Ray GenerateMouseRay (Vector3 touchPos) {
		Vector3 mousePosFar = new Vector3(touchPos.x, touchPos.y, Camera.main.farClipPlane);
		Vector3 mousePosNear = new Vector3(touchPos.x, touchPos.y, Camera.main.nearClipPlane);
		Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
		Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);
		Debug.DrawRay(mousePosN, mousePosF-mousePosN, Color.green);

		Ray mr = new Ray(mousePosN, mousePosF-mousePosN);
		return mr;
	}

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		//Debug.Log("start color: " + rend.material.color);

		//float halfPlayerWidth = transform.localScale.x / 2f;
		screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;

		}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0)) {
			Ray mouseRay = GenerateMouseRay();
			RaycastHit hit;

			if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit)) {
				//Destroy(hit.transform.gameObject);
				gObj = hit.transform.gameObject;
				objPlane = new Plane(Camera.main.transform.forward*-1, gObj.transform.position);
				
				//calc mouse offset
				Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
				float rayDistance;
				objPlane.Raycast(mRay, out rayDistance);
				mO = gObj.transform.position - mRay.GetPoint(rayDistance);
			}
		}
		else if (Input.GetMouseButton(0) && gObj) {
			Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			float rayDistance;
			if (objPlane.Raycast(mRay, out rayDistance)) {
				gObj.transform.position = mRay.GetPoint(rayDistance) + mO;
			}
		}
		else if (Input.GetMouseButtonUp(0) && gObj) {
			gObj = null;
		}		

		if (Input.touchCount > 0) {
			if (Input.GetTouch(0).phase == TouchPhase.Began) {
				Ray mouseRay = GenerateMouseRay(Input.GetTouch(0).position);
				RaycastHit hit;

				if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit)) {
					gObj = hit.transform.gameObject;
					objPlane = new Plane(Camera.main.transform.forward*-1, gObj.transform.position);

					//calc touch offset
					Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
					float rayDistance;
					objPlane.Raycast(mRay, out rayDistance);
					mO = gObj.transform.position - mRay.GetPoint(rayDistance);
				}
			}
			else if (Input.GetTouch(0).phase == TouchPhase.Moved && gObj) {
				Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
				float rayDistance;
				if (objPlane.Raycast(mRay, out rayDistance))
				gObj.transform.position = mRay.GetPoint(rayDistance) + mO;
			}
			else if (Input.GetTouch(0).phase == TouchPhase.Ended && gObj) {
				gObj = null;
			}
		}

		if(Input.GetKey(KeyCode.Space)) {
			
			StartCoroutine(cameraShake.Shake(.15f, .4f));

			//timeManager.DoSlowmotion();
		}

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

		/* 
		if(Input.GetKey(KeyCode.Space)) {
			float lerp = Mathf.PingPong(Time.time, duration) / duration;
			rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
			Debug.Log("now color: " + rend.material.color);
						
		} */

		if(Input.GetKey(KeyCode.R)) {
			theDeathScreen.SetActive(true);			
		}

		if (Input.GetKeyDown("escape")) {
            	Application.Quit();
        	}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Block") {
			
			StartCoroutine(cameraShake.Shake(.15f, .4f));
			GameObject.Find("ScoreManager").SendMessage("GetBlock");
			Destroy(other.gameObject);
		}
				
	}
}
