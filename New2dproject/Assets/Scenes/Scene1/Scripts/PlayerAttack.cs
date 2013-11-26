using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Rigidbody bulletPrefab;
	private float bulletSpeed = 10.0f;

	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z)){
			bulletAttack();		
		}
	}

	void bulletAttack() {
		Rigidbody instantiatedProjectile =  (Rigidbody)Instantiate(bulletPrefab, transform.position, transform.rotation);
		
		// get target in world space, at same distance from camera:
		Vector3 targetScreenPos = Input.mousePosition;
		var targetPosition = Camera.main.ScreenToWorldPoint(targetScreenPos);
		
		// calculate direction & velocity:
		Vector3 targetDelta = (targetPosition - transform.position);

		Vector3 launchVelocity = targetDelta.normalized * bulletSpeed;	//Vector3.normalized returns a read-only copy of the vector with a magnitude of 1
		print ("targetDelta.normalized = " + targetDelta.normalized.ToString());
		print ("launchVelocity = " + launchVelocity.ToString());
		launchVelocity.z = 0;
		instantiatedProjectile.velocity = launchVelocity;
//		instantiatedProjectile.transform.LookAt(transform.position);
//		instantiatedProjectile.AddForce(instantiatedProjectile.transform.forward * bulletSpeed);



	}
}
