using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Missile : MonoBehaviour {

	public Transform target;
	public float speed = 1f;
	public float rotateSpeed = 200f;

	public GameObject explosionEffect = null;

	private Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		//target = GameObject.FindGameObjectWithTag("Player").transform;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate  () {
		Vector3 direction = target.position - rb.position;

		direction.Normalize();
		float rotateAmount = Vector3.Cross(direction, transform.up).z;

		rb.angularVelocity = new Vector3 (0, 0, -rotateAmount * rotateSpeed);
		
		rb.velocity = transform.up * speed;
	}

	void OnTriggerEnter () {
		//Instantiate(explosionEffect, transform.position, transform.rotation);
		Debug.Log("missile");
		Destroy(gameObject);
	}
}
