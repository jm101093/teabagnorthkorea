using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float movementSpeed = 5.0f;
	
	public float takenDamage = 0.5f;

	//jumping data
	public bool letsJump = false;
	public float jumpStrength = 0.0f;
	public float jumpStrengthAdd = 0.05f;
	private bool isGrounded = false;
	public float gravity = 36.0f;
	public float jumpVariable;
	public float jumpHeight = 5.5f;

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
		//left and right movement
		if (Input.GetKey("left") || Input.GetKey ("a")) {
			transform.position -= Vector3.right * movementSpeed * Time.deltaTime;
		}

		if (Input.GetKey("right") || Input.GetKey ("d")) {
			transform.position += Vector3.right * movementSpeed * Time.deltaTime;
		}
//		//player jump
//		if (Input.GetButtonDown("Jump") && isGrounded) {
//			Jump();
//		}

		// Jump
		if (isGrounded == true && Input.GetKeyDown ("space")) {
			letsJump = true;
		}
		
		// Not jumping
		if (isGrounded == false || Input.GetKeyUp ("space")) {
			letsJump = false;    
		}
		
		// Gets sensitivity on the Space Bar press
		if (Input.GetKey ("space")) {
			jumpStrength += jumpStrengthAdd;
			jumpStrength = Mathf.Clamp(jumpStrength, 0, 2);
			jumpVariable = Mathf.Sqrt(jumpStrength * jumpHeight * gravity);
			
		}
		
		// Resets the sensitivity
		if (Input.GetKeyUp ("space")) {
			jumpStrength = 0f;
			jumpVariable = 0f;	
		}
	}

//	void Jump() {
//		if (!isGrounded) {
//			return;
//		}
//		if (isGrounded) {
//			rigidbody.AddForce(new Vector3(0,jumpHeight,0),ForceMode.Force);
//		}
//	}

	void FixedUpdate() {
		isGrounded = Physics.Raycast(transform.position, -Vector3.up, 1.0f);

		// Jump
		if (letsJump == true) {   
			System.Console.WriteLine("setting rigidbody.velocity, jumpVariable: " + jumpVariable); 
			rigidbody.velocity = new Vector3(0, jumpVariable, 0);
		}
	}

	public IEnumerator TakenDamage() {
		renderer.enabled = false;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = false;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = false;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds(takenDamage);
	}

	public IEnumerator healed() {
		renderer.enabled = false;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = true;
	}
}
