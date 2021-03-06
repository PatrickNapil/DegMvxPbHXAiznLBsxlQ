﻿using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {

	public int healthToGive;

	public AudioSource healthSoundEffect;

	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<PlayerController> () == null)
			return;

		HealthManager.HurtPlayer (-healthToGive);

		healthSoundEffect.Play ();

		Destroy (gameObject);
	}
}
