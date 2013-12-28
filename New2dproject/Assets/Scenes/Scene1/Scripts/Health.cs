using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public GameManager gameManager;
	public int healthValue = 1;

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			gameManager.SendMessage("playerHealed", healthValue, SendMessageOptions.DontRequireReceiver);
			gameManager.playerMovement.SendMessage("healed",SendMessageOptions.DontRequireReceiver);
			Object.Destroy(gameObject);
		}
	}
}
