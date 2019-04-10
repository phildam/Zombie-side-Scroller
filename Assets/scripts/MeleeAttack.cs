using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

	public float damage;
	public float knockBack;
	public float knockBackRadius;
	public float meleeRate;

	private float nextMelee;
	private int shootableMask;

	private Animator myAnim;
	private PlayerController myPC;

	void Start () {
		shootableMask = LayerMask.GetMask("Shootable");
		myAnim = transform.root.GetComponent<Animator>();
		myPC = transform.root.GetComponent<PlayerController>();
		nextMelee = 0f;
	}
	
	void FixedUpdate () {
		float melee = Input.GetAxis("Fire2");
		if(melee > 0 && nextMelee <= Time.time && !(myPC.isRunning())) {
			myAnim.SetTrigger("gunMelee");
			nextMelee = Time.time + meleeRate;

			//do damage
			Collider[] attacked = Physics.OverlapSphere(transform.position, knockBackRadius, shootableMask);

		}
	}
}
