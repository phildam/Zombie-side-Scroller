using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupController : MonoBehaviour {

	// Use this for initialization
	public int healthAmount = 10;
	public AudioClip audioClip;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
			playerHealth.addHealth(healthAmount);
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(audioClip, transform.position, 1f);
		}
		
	}
}
