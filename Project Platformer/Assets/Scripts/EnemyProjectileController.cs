using UnityEngine;
using System.Collections;

public class EnemyProjectileController : MonoBehaviour {

	public float speed;

	public PlayerController player;

	//public ParticleSystem enemyDeathParticle;

	public ParticleSystem impactEffect;

	//public int pointsForKill;

	public float rotationSpeed;

	public int damageToGive;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

		if (player.transform.position.x < transform.position.x) {
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}

	}

	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);

		GetComponent<Rigidbody2D> ().angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			//Instantiate (enemyDeathParticle, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);
			//ScoreManager.AddPoints (pointsForKill);

			HealthManager.HurtPlayer (damageToGive);
		}

		Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
