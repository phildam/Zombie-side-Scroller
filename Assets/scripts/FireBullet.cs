using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBullet : MonoBehaviour {

	public float timeBetweenBullets = 0.15f;
	public GameObject projectile;
	public int maxRound = 100;
	public int startingRound = 100;
	int remainingRounds;
	float nextBullet;

	public Slider playerAmmoSlider;
	AudioSource gunMuzzleAS;
	public AudioClip shootSound;
	public AudioClip reloadSound;

	void Awake() {
		nextBullet = 0f;
		remainingRounds = startingRound;
		playerAmmoSlider.maxValue = maxRound;
		playerAmmoSlider.value = remainingRounds;
		gunMuzzleAS = GetComponent<AudioSource>();
	}
	
	void Update () {
		PlayerController myPlayer = transform.root.GetComponent<PlayerController>();
		if(Input.GetAxisRaw("Fire1") > 0 && nextBullet < Time.time && remainingRounds > 0) {
			nextBullet = Time.time + timeBetweenBullets;
			Vector3 rot = new Vector3(0, 90, 0); 
			if(myPlayer.getFacingDirection() == -1f) {
				rot *= -1;
			}

			Instantiate(projectile, transform.position, Quaternion.Euler(rot));
			playSound(shootSound);

			remainingRounds -= 1;
			playerAmmoSlider.value = remainingRounds;
		}
	}

	public void manualReload(int roundCount) {
		reloadWeapon(Mathf.Clamp(roundCount + remainingRounds, 0, maxRound));
	}

	public void fullReload() {
		reloadWeapon(maxRound);
	}

	private void reloadWeapon(int newRounds) {
		remainingRounds = newRounds;
		playerAmmoSlider.value = remainingRounds;
		playSound(reloadSound);
	}

	private void playSound(AudioClip clip) {
		gunMuzzleAS.clip = clip;
		gunMuzzleAS.Play();
	}

}
