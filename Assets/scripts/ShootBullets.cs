using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour {

	public float range = 10f;
	public float damage = 5f;
	public float bulletForce = 100f;

	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;
	LineRenderer gunLine;

	void Start () {
		shootableMask = LayerMask.GetMask("Shootable");
		gunLine = GetComponent<LineRenderer>();

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;
		gunLine.SetPosition(0, transform.position);

		if (Physics.Raycast(shootRay, out shootHit, range, shootableMask)) {
			// hit an ememy goes here
			gunLine.SetPosition(1, shootHit.point);
			if(shootHit.rigidbody != null) {
				Rigidbody rb = shootHit.rigidbody;
				rb.angularDrag = 0.8F;
				rb.AddForce(shootRay.direction * bulletForce);
			}
			
		} else {
			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
