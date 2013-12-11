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

//	public GameObject explosion;		// Prefab of explosion effect.
//	
//	
//	void Start () 
//	{
//		// Destroy the rocket after 2 seconds if it doesn't get destroyed before then.
//		Destroy(gameObject, 2);
//	}
//	
//	
//	void OnExplode()
//	{
//		// Create a quaternion with a random rotation in the z-axis.
//		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
//		
//		// Instantiate the explosion where the rocket is with the random rotation.
//		Instantiate(explosion, transform.position, randomRotation);
//	}
//	
//	void OnTriggerEnter2D (Collider2D col) 
//	{
//		// If it hits an enemy...
//		if(col.tag == "Enemy")
//		{
//			// ... find the Enemy script and call the Hurt function.
//			col.gameObject.GetComponent<Enemy>().Hurt();
//			
//			// Call the explosion instantiation.
//			OnExplode();
//			
//			// Destroy the rocket.
//			Destroy (gameObject);
//		}
//		// Otherwise if it hits a bomb crate...
//		else if(col.tag == "BombPickup")
//		{
//			// ... find the Bomb script and call the Explode function.
//			col.gameObject.GetComponent<Bomb>().Explode();
//			
//			// Destroy the bomb crate.
//			Destroy (col.transform.root.gameObject);
//			
//			// Destroy the rocket.
//			Destroy (gameObject);
//		}
//		// Otherwise if the player manages to shoot himself...
//		else if(col.gameObject.tag != "Player")
//		{
//			// Instantiate the explosion and destroy the rocket.
//			OnExplode();
//			Destroy (gameObject);
//		}
//	}

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