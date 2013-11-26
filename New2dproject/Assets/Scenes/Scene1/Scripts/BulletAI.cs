using UnityEngine;
using System.Collections;

public class BulletAI : MonoBehaviour {
	
	int damageValue = 1;

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Enemy"){
			other.gameObject.SendMessage("EnemyDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 newPosition = transform.position;
		//newPosition.y += speed * Time.deltaTime;
		//transform.position = newPosition;
	}
}
//	// Use this for initialization
//	void Start () {
//		Vector3 newVelocity = Vector3.zero;
//		newVelocity.x += speed * Time.deltaTime; 
//		rigidbody.velocity = newVelocity;
//	}