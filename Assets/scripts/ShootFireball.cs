using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireball : MonoBehaviour {

	public float damage;
	public float speed;

	Rigidbody myRb;

	void Start () {
		myRb = GetComponentInParent<Rigidbody>();

		if(transform.rotation.y > 0) {
			myRb.AddForce(Vector3.right * speed, ForceMode.Impulse);
		} else {
			myRb.AddForce(Vector3.right * -speed, ForceMode.Impulse);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.layer == LayerMask.NameToLayer("Shootable")) {
			print("got shootable");
			myRb.velocity = Vector3.zero;
			Destroy(gameObject);
		}
	}
}
