using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmoLoader : MonoBehaviour {

	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			other.GetComponentInChildren<FireBullet>().fullReload();
			Destroy(gameObject);
		}
		
	}
}
