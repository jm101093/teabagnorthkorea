using UnityEngine;
using System.Collections;

public class Crate1 : MonoBehaviour {

	int enemyHealth = 6;

	public GameObject explode;

	public AudioClip owie;

	void EnemyDamaged(int damaged){
		if(enemyHealth > 0){
			enemyHealth -= damaged;
			audio.Play();
			//print ("enemyHealth" + enemyHealth.ToString());
			
		}
		if(enemyHealth <=0){
			enemyHealth = 0;
			audio.Play();
			Instantiate(explode, transform.position, transform.rotation);
			Destroy(gameObject);
			//print ("enemyHealth" + enemyHealth.ToString());
			
		}
	}
}
