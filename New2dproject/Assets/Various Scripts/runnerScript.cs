using UnityEngine;
using System.Collections;

public class runnerScript : MonoBehaviour {
	
	public Vector3 jumpVelosity;
		
	private bool touchGround = false;
	
	// Update is called once per frame
	void Update () {
		
		if(touchGround && Input.GetButtonDown("Jump")){
		rigidbody.AddRelativeForce(jumpVelosity, ForceMode.VelocityChange);
		touchGround = false;
			
		//}
		
		//if(touchGround && currentSpeed.magnitude < maxSpeed){
		//rigidbody.AddRelativeForce (Acceleration,0,0);
		}
	}	
	void OnCollisionEnter(){
			
		touchGround = true;
	}
		
}