using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	private bool grounded;
	private bool doubleJumped;
	private bool willShoot;
	private bool hurt;
	private bool jumped;

	private Animator anim;

	public Transform firePoint;
	public GameObject projectile;

	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {
		if (grounded)
			doubleJumped = false;

		anim.SetBool ("Grounded", grounded);

		#if UNITY_STANDALONE || UNITY_WEBPLAYER
		if (Input.GetButtonDown("Jump") && grounded) {
			Jump ();
		}

		if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded) {
			jumped = true;
			Jump ();
			doubleJumped = true;
		}



		//moveVelocity = 0f;

		//moveVelocity = moveSpeed * Input.GetAxisRaw ("Horizontal");
		Move(Input.GetAxisRaw ("Horizontal"));
		#endif

		anim.SetBool ("Jumped", jumped);
		jumped = false;
		hurt = true;

		if (knockbackCount <= 0) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);
			anim.SetBool ("Hurt", false);
		} else {
			anim.SetBool ("Hurt", hurt);
			if (knockFromRight) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-knockback, knockback);
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			}
			if (!knockFromRight) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (knockback, knockback);
				transform.localScale = new Vector3 (1f, 1f, 1f);
			}
			knockbackCount = knockbackCount - Time.deltaTime;
		}

			
		anim.SetFloat ("Speed", Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x));

		if (GetComponent<Rigidbody2D> ().velocity.x > 0) {
			transform.localScale = new Vector3 (1f, 1f, 1f);
			projectile.transform.localScale = new Vector3 (1f, 1f, 1f);
		} else if(GetComponent<Rigidbody2D> ().velocity.x < 0) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
			projectile.transform.localScale = new Vector3 (-1f, 1f, 1f);
		}

		#if UNITY_STANDALONE || UNITY_WEBPLAYER
		if(Input.GetButtonDown("Fire1")) {
			willShoot = true;
			//Instantiate (projectile, firePoint.position, firePoint.rotation);
			FireProjectile();
		}

		anim.SetBool ("WillShoot", willShoot);
		willShoot = false;
		#endif
	}

	public void Move(float moveInput) {
		moveVelocity = moveSpeed * moveInput;
	}

	public void FireProjectile() {
		//Instantiate (projectile, firePoint.position, firePoint.rotation);
	}
		
	public void Jump() {
		//GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	
		if (grounded) {
			//Jump ();
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}

		if (!doubleJumped && !grounded) {
			jumped = true;
			//Jump ();
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
			doubleJumped = true;
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D (Collision2D other) {
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}
}

