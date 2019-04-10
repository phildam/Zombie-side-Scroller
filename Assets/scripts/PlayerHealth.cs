using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float fullHealth = 100;
	public float currentHealth;
	public GameObject playerDeathPrefab;

	public Slider playerHealthslider;
	public Image damageIndicator;
	Color flashcolor = new Color(255f, 255f, 255f, 1);
	float flashSpeed = 5f;
	bool damaged = false;
	AudioSource playerAudioSource;

	void Start () {
		currentHealth = fullHealth;

		playerHealthslider.maxValue = fullHealth;
		playerHealthslider.minValue = 0;
		playerHealthslider.value = currentHealth;
		playerAudioSource = GetComponent<AudioSource>();
	}
	
	
	void Update () {
		if(damaged) {
			damageIndicator.color = flashcolor;
		} else {
			damageIndicator.color = Color.Lerp(damageIndicator.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public void addDamage(float damage) {
		currentHealth -= damage;
		playerHealthslider.value = currentHealth;
		damaged = true;
		playerAudioSource.Play();
		if(currentHealth <= 0) {
			makeDead();
		}
	}

	public void makeDead() {
		Object deathPrefab = Instantiate(playerDeathPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
		Destroy(deathPrefab, 2.0f);
		damageIndicator.color = flashcolor;
	}

	public void addHealth(int health) {
		currentHealth += health;
		currentHealth = Mathf.Clamp(currentHealth, 0, fullHealth);
		playerHealthslider.value = currentHealth;
	}
}
