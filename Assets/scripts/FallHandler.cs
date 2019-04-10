using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallHandler : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
			if(playerHealth != null) {
				playerHealth.makeDead();
			}
		} else {
			Destroy(other.gameObject);
		}
    }

}
