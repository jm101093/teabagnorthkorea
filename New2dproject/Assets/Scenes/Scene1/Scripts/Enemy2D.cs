using UnityEngine;
using System.Collections;

public class Enemy2D : MonoBehaviour {

	public GameManager gameManager;

	//enemys starting and ending positions
	float startingPos;
	float endPos;
	//units enemy moves right
	public int unitsToMove = 5;
	//units enemy moves left
	public int moveSpeed = 2;
	public int damageValue = 1;
	//sound effect for hurt
	public AudioClip owie;

	//enemy move Dirrection
	public bool moveRight = true;

	//enemy health
	int enemyHealth = 1;
	//Enemy2D type
	public bool basicEnemy;
	public bool advancedEnemy;
	public bool motherFucker;

	void Awake() {
		startingPos = transform.position.x;
		endPos = startingPos + unitsToMove;

		if(basicEnemy){
			enemyHealth = 3;
			print("enemyHealth" + enemyHealth.ToString());
		}

		if(advancedEnemy){
			enemyHealth = 5;
			print("enemyHealth" + enemyHealth.ToString());
		}

		if(motherFucker){
			enemyHealth = 10;
			print("enemyHealth" + enemyHealth.ToString());
		}
	}

	void Update() {

		if(moveRight){
			this.rigidbody.position += Vector3.right * moveSpeed * Time.deltaTime;
		}

		if(this.rigidbody.position.x >= endPos){
			moveRight = false;
		}

		if(!moveRight){
			this.rigidbody.position -= Vector3.right * moveSpeed * Time.deltaTime;
		}

		if(this.rigidbody.position.x <= startingPos){
			moveRight = true;
		}

	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			gameManager.SendMessage("playerDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
			gameManager.playerMovement.SendMessage("TakenDamage",SendMessageOptions.DontRequireReceiver);

		}
	}

	void EnemyDamaged(int damaged){
		if(enemyHealth > 0){
			enemyHealth -= damaged;
			audio.Play();
			print ("enemyHealth" + enemyHealth.ToString());

		}
		if(enemyHealth <=0){
			enemyHealth = 0;
			audio.Play();
			Destroy(gameObject);
			print ("enemyHealth" + enemyHealth.ToString());

		}
	}
}
