using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;

	public Text tCount;

	GameObject gObj = null;
	Plane objPlane;
	Vector3 mO;

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
	
	// Update is called once per frame
	void Update () {
		scoreText.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();

		//tCount.text = Input.GetMouseButton(0).ToString();
		tCount.text = Input.touchCount.ToString();
		
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
	}
}
