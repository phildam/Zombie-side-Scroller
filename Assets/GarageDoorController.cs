using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageDoorController : MonoBehaviour {

	// Use this for initialization
	public bool resetable;
	public GameObject door;
	public GameObject gear;
	public bool startOpen;

	bool firstTrigger = false;
	bool open = true;
	Animator doorAnim;
	Animator gearAnim;
	AudioSource doorAudio;

	void Start () {
		doorAnim = door.GetComponent<Animator>();
		gearAnim = gear.GetComponent<Animator>();
		doorAudio = GameObject.FindWithTag("GarageDoor").GetComponent<AudioSource>();

		if(!startOpen) {
			open = false;
			doorAnim.SetTrigger("doorTrigger");
			doorAudio.Play();
		}
	}
	
	private void OnTriggerEnter(Collider other) {
		if(other.tag == "Player" && !firstTrigger) {
			if(!resetable) firstTrigger = true;
			open = !open;
			doorAnim.SetTrigger("doorTrigger");
			gearAnim.SetTrigger("gearTrigger");
			doorAudio.Play();
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
