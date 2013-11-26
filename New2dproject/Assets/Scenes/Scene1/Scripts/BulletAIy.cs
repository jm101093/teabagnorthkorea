using UnityEngine;
using System.Collections;

public class BulletAIy : MonoBehaviour {
	
	public float speed;

	void Start () {
		Vector3 newVelocity = Vector3.zero;
		newVelocity.y += speed; 
		rigidbody.velocity = newVelocity;
	}

}
