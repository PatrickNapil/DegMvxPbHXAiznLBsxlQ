using UnityEngine;
using System.Collections;

public class GemPickedUp : MonoBehaviour {

	public int pointsToAdd;

	public AudioSource gemSoundEffect;

	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<PlayerController> () == null)
			return;

		ScoreManager.AddPoints (pointsToAdd);

		gemSoundEffect.Play ();

		Destroy (gameObject);
	}
}
