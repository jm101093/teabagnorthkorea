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

	//used for reload
	public bool CanShoot = true;

	//calls explosion
	public GameObject die;

	//enemy weapon
	public GameObject enemyBullett;

	//randomly generated shoot time
	public float waitToShootTime;

	//enemy move Dirrection
	public bool moveRight = true;

	//enemy health
	int enemyHealth = 1;
	//Enemy2D type
	public bool basicEnemy;
	public bool advancedEnemy;
	public bool motherFucker;

	void Awake() {

		//random shoot time generation
		waitToShootTime = Random.Range(10.0f, 20.0f);
		//print ("Shooting time is " + waitToShootTime.ToString());

		//walking
		startingPos = transform.position.x;
		endPos = startingPos + unitsToMove;

		if(basicEnemy){
			enemyHealth = 6;
			//print("enemyHealth" + enemyHealth.ToString());
		}

		if(advancedEnemy){
			enemyHealth = 10;
			//print("enemyHealth" + enemyHealth.ToString());
		}

		if(motherFucker){
			enemyHealth = 18;
			//print("enemyHealth" + enemyHealth.ToString());
		}
		if(CanShoot = true){
			InvokeRepeating("ShootTime", 5, waitToShootTime);
			//print ("Canshoot if statement " + CanShoot.ToString());
		}
	}

	void Update() {

		//please dont kill me the bug is here
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

	//shooting or bug here
	void ShootTime(){
		Instantiate(enemyBullett, transform.position, transform.rotation);
		//print ("Shooting boom boom ");
		CanShoot = false;
		Reload (waitToShootTime);
	}

	//reload time  or bug here

	IEnumerator Reload(float waitToShootTime){
		//print ("Reloading " + waitToShootTime.ToString());
		yield return new WaitForSeconds(10.0f);
		CanShoot = true;
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
			//print ("enemyHealth" + enemyHealth.ToString());

		}
		if(enemyHealth <=0){
			enemyHealth = 0;
			audio.Play();
			Instantiate(die, transform.position, transform.rotation);
			Destroy(gameObject);
			//print ("enemyHealth" + enemyHealth.ToString());

		}
	}
}
