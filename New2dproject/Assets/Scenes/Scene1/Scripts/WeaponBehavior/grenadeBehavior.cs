using UnityEngine;
using System.Collections;

public class grenadeBehavior : MonoBehaviour {

	public AudioClip explode;
	public Rigidbody grenadeRigidBody;

	void Start() {
		StartCoroutine(PhysicsOff(1.5f));
		StartCoroutine(WaitAndPrint(3.2f));
		Object.Destroy(gameObject, 3.5f);
		 
	}
	
	IEnumerator PhysicsOff(float waitTime) {
		grenadeRigidBody.Sleep();
		grenadeRigidBody.detectCollisions = false;
		print("Physics off " + Time.time);
		yield return new WaitForSeconds(waitTime);
		print("Physics off 2 " + Time.time);

	}
	
	IEnumerator WaitAndPrint(float waitTime) {
		grenadeRigidBody.detectCollisions = true;
		grenadeRigidBody.WakeUp();
		print("Physics on " + Time.time);
		yield return new WaitForSeconds(waitTime);
		audio.Play();
		print("WaitAndPrint " + Time.time);
	}
}