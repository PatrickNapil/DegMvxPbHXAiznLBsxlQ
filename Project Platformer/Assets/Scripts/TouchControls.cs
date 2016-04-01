using UnityEngine;
using System.Collections;

public class TouchControls : MonoBehaviour {

	private PlayerController player;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	public void LeftArrow() {
		player.Move (-1);
		Debug.Log ("Moving Left");
	}

	public void RightArrow() {
		player.Move (1);
		Debug.Log ("Moving Right");
	}

	public void UnpressedArrow() {
		player.Move (0);
		Debug.Log ("Not Moving");
	}

	public void FireProjectile() {
		player.FireProjectile ();
		Debug.Log ("Firing Projectile");
	}

	public void Jump() {
		player.Jump ();
		Debug.Log ("Jumping");
	}
}
