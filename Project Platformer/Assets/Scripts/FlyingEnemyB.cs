using UnityEngine;
using System.Collections;

public class FlyingEnemyB : MonoBehaviour {

	public float attackDelay = 1f;
	public float aimDelay = 1f;
	private Animator animator;
	public OrangeRock projectile;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();

		StartCoroutine(OnAttack());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnAttack() {
		yield return new WaitForSeconds (aimDelay);
		Aim ();
		yield return new WaitForSeconds (attackDelay);
		Fire ();
		StartCoroutine (OnAttack ());
	}

	void Fire() {
		animator.SetInteger ("AnimState", 1);
	}

	void Aim() {
		animator.SetInteger ("AnimState", 0);
	}

	void OnShoot() {
		if (projectile) {
			OrangeRock falling_rock = Instantiate (projectile, transform.position,
				                          Quaternion.identity) as OrangeRock;
		}
	}
}
