using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

	public Animator anim;
	public float shieldTime;
	public float fireTime;
	public float moveTime;
	public float stunnedTime;
	public float jumpTime;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		moveTime -= Time.deltaTime;

		if (moveTime <= 0) {
			anim.SetBool ("WillMove", true);
		}
		anim.SetBool ("WillMove", true);

	}
}
