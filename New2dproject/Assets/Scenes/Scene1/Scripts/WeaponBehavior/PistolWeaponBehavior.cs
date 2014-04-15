// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using System.Collections;
using UnityEngine;

	public class PistolWeaponBehavior : WeaponBehavior
	{
		//public Rigidbody bulletPrefab;
		private float bulletSpeed = 10.0f;
		public Vector3 spreadRange;

		public PistolWeaponBehavior ()
		{
		}

		override public void FireWeapon(UnityEngine.Object playerObject, Transform playerTransform, Rigidbody bulletPrefab)
		{
			Rigidbody instantiatedProjectile =  (Rigidbody)Instantiate(bulletPrefab, playerTransform.position, playerTransform.rotation);
			
			// get target in world space, at same distance from camera:
			Vector3 targetScreenPos = Input.mousePosition;
			var targetPosition = Camera.main.ScreenToWorldPoint(targetScreenPos);
			
			// calculate direction & velocity:
			Vector3 targetDelta = (targetPosition - playerTransform.position);
			targetDelta.z = 0;	//we dont care about the z-axis in a 2d game
			Vector3 launchVelocity = targetDelta.normalized * bulletSpeed;	//Vector3.normalized returns a read-only copy of the vector with a magnitude of 1
			//print ("targetDelta.normalized = " + targetDelta.normalized.ToString());
			//print ("launchVelocity = " + launchVelocity.ToString());
			
			
			instantiatedProjectile.velocity = launchVelocity;

			//		instantiatedProjectile.transform.LookAt(transform.position);
			//		instantiatedProjectile.AddForce(instantiatedProjectile.transform.forward * bulletSpeed);
		}
	}
