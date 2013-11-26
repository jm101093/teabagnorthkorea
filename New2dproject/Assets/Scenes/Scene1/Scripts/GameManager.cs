using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public PlayerMovement playerMovement;

	public Texture playersHealthTexture;
	public float screenPositionX;
	public float screenPositionY;
	//
	public int iconSizeX;
	public int iconSizeY;
	
	public int playersHealth = 3;

	void OnGUI(){

		for(int h = 0; h < playersHealth; h++){
			GUI.DrawTexture(new Rect(screenPositionX + (h * iconSizeX), screenPositionY, iconSizeX, iconSizeY), playersHealthTexture,ScaleMode.ScaleToFit, true, 0);
		}

	}

	void playerDamaged(int damage){
		if(playersHealth > 0){
			playersHealth -= damage;
		}

		if(playersHealth <= 0){
			playersHealth = 0;
			RestartScene();
		}
	}

	void RestartScene(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
