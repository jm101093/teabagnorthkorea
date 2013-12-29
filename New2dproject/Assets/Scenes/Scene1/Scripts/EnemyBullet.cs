using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

private float lifeSpan = 2.0f;
private float projectileSpeed = 10f;

public Transform player;

public int damageValue = 1;

Vector3 dir;

void Start(){
        //gets the players transform
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //the direction the projectile will travel
        dir = player.position - transform.position;
}

void Update(){
        rigidbody.velocity = dir.normalized * projectileSpeed;
        //Physics.IgnoreCollision(this.collider, collider);
        //Destroys the projectile after it has lived its life
        Destroy(this.gameObject, lifeSpan);
    }

void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			other.gameObject.SendMessage("playerDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
			print ("damageValueEB " + damageValue.ToString());
			Destroy(gameObject);
		}
	}

//void OnCollisionEnter(Collision other){
//        if(other.gameObject.tag !=  "Enemy"){
//            if(other.gameObject.tag !=  "EnemyProjectile"){
//            audio.Play(); 
//            Destroy(this.gameObject);  
//            }
//
//        }
//
//    }

    
}
