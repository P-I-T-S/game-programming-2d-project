using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour
{
		public float playerSpeed = 7;
		bool facingRight;
		public bool canJump = false;
		private Animator anim;
		public bool canAttack = false;

		void Start ()
		{
				facingRight = true;
				anim = GetComponent<Animator> ();
		}

		void FixedUpdate ()
		{
				//Gather input
				float horizontal = Input.GetAxis ("Horizontal");
				float vertical = Input.GetAxisRaw ("Vertical");
				bool attacking = Input.GetKeyDown (KeyCode.Space);
				
				//Set animation based on current player status
				if (horizontal > 0)
						facingRight = true;
				else if (horizontal < 0)
						facingRight = false;
	
				anim.SetFloat ("speed", Mathf.Abs (horizontal));
				anim.SetBool ("facingRight", facingRight);
				anim.SetBool ("attacking", attacking);

				if (attacking) {
					GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
					if(enemies.Length > 0) {
						foreach(GameObject enemy in enemies) {
							
						}
						//TODO
						//Here is where the damage is delt to enemys
					}
				}

				//Move player horizontally
				rigidbody2D.velocity = new Vector2 (horizontal * playerSpeed, rigidbody2D.velocity.y);
				
				//Handle jump
				if (canJump) {
						if (vertical == 1.0f) {

								rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 0.0f);
								rigidbody2D.AddForce (Vector2.up * 250.0f);
								canJump = false;
						}
				}
		}

		void OnCollisionEnter2D (Collision2D coll)
		{
				//If the player is on the ground, then allow jumping
				if (coll.gameObject.tag == "ground") {
						canJump = true;
				} else {
						canJump = false;
				}
		}
}