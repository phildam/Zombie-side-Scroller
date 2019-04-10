using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour {

	public float resetTime = 5.0f;
	Animator animator;
	AudioSource audioSource;

	float downTime;
	bool elevUp = false;

	void Start () {
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}
	
	void FixedUpdate () {
		if(Time.time >= downTime && elevUp) {
			animator.SetTrigger("startElevator");
			elevUp = false;
			audioSource.Play();
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			animator.SetTrigger("startElevator");
			downTime = Time.time + resetTime;
			elevUp = true;
			audioSource.Play();
		}
	}
}
