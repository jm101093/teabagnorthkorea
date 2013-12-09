using System;
using System.Collections;
using UnityEngine;

	public class grenadeWeaponBehavior : WeaponBehavior 	{
		//This is for a grenade.  when finished it shoul duse physics and roll around and be effected by gravity
		// press G to fire.  grenade prefab has been added and has a particle system (smoke).
		//need to find a way to make this guy passthrough the player and then enable collision
	    // also shoot raycast when exploding after 10 seconds  http://answers.unity3d.com/questions/15838/how-can-i-apply-damage-based-on-a-grenade-explosio.html
		//raycast can also be used for economic santions
		//should use collider.enabled for collider  http://docs.unity3d.com/Documentation/ScriptReference/Collider-enabled.html
		//Something like if collider col = player collision.enabled = false or some shit.
		//OnTriggerEnter(Collider col){
		//if(col.gameObject.tag == "Player"){
	    //collision.enabled = false}
		private float bulletSpeed = 8.0f;
		public Vector3 spreadRange;

		public grenadeWeaponBehavior ()
		{
		}

		override public void FireWeapon(UnityEngine.Object playerObject, Transform playerTransform, Rigidbody grenadePrefab)
		{
			Rigidbody instantiatedProjectile =  (Rigidbody)Instantiate(grenadePrefab, playerTransform.position, playerTransform.rotation);
			
			// get target in world space, at same distance from camera:
			Vector3 targetScreenPos = Input.mousePosition;
			var targetPosition = Camera.main.ScreenToWorldPoint(targetScreenPos);
			
			// calculate direction & velocity:
			Vector3 targetDelta = (targetPosition - playerTransform.position);
			targetDelta.z = 0;	//we dont care about the z-axis in a 2d game
			Vector3 launchVelocity = targetDelta.normalized * bulletSpeed;	//Vector3.normalized returns a read-only copy of the vector with a magnitude of 1
			print ("targetDelta.normalized = " + targetDelta.normalized.ToString());
			print ("launchVelocity = " + launchVelocity.ToString());
			
			instantiatedProjectile.velocity = launchVelocity;
			Destroy(gameObject, 1f);
			//		instantiatedProjectile.transform.LookAt(transform.position);
			//		instantiatedProjectile.AddForce(instantiatedProjectile.transform.forward * bulletSpeed);
		}
	}