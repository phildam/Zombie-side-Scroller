using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	public float damage = 10;
	public float damageRate = 1;
	public float pushBackForce = 30;

	float nextDamage;
	public bool playerInRange = false;
	GameObject thePlayer;
	PlayerHealth playerHealth;

	void Start () {
		nextDamage = 0f;
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		playerHealth = thePlayer.GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		if(playerInRange) attack();
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.tag == "Player") {
			playerInRange = false;
		}
	}

	void attack() {
		if(playerHealth != null) {
			if(nextDamage <= Time.time) {
				playerHealth.addDamage(damage);
				nextDamage = Time.time + damageRate;
				pushBack(thePlayer);
			}
		}
	}

	void pushBack(GameObject player) {
		PlayerController pc = player.GetComponent<PlayerController>();
		float facingDirection = pc.getFacingDirection();
		float pushXDirection =  player.transform.position.x - (10 * facingDirection);

		Vector3 pushDirection = new Vector3(pushXDirection, (player.transform.position.y - transform.position.y), 0).normalized;
		Rigidbody rb = player.GetComponent<Rigidbody>();
		rb.velocity = Vector3.zero;
		rb.AddForce(pushDirection * pushBackForce, ForceMode.Impulse);
	}
}
