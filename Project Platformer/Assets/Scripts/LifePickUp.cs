using UnityEngine;
using System.Collections;

public class LifePickUp : MonoBehaviour {

	private LifeManager lifeSystem;

	public AudioSource lifeSoundEffect;

	// Use this for initialization
	void Start () {
		lifeSystem = FindObjectOfType<LifeManager> ();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			lifeSoundEffect.Play ();
			Debug.Log ("Life is Given");
			lifeSystem.GiveLife ();
			Destroy (gameObject);
		}
	}
}
