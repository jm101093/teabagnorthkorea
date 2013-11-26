using UnityEngine;
using System.Collections;

public class Mainmenu : MonoBehaviour {

	public GUIStyle Random1;
	public GUIStyle Random2;

	public Texture backgroundTexture;

	public float guiPlacementx1;
	public float guiPlacementx2;
	public float guiPlacementy1;
	public float guiPlacementy2;

	public bool guiOutline = true;

	void OnGUI(){

		//display background texture
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backgroundTexture);
		//display buttons

		if(guiOutline){
			if (GUI.Button (new Rect(Screen.width * guiPlacementx1, Screen.height * guiPlacementy1, Screen.width *.25f, Screen.height *.1f),"Play Game")){
				Application.LoadLevel("Scene1");
			}

			if (GUI.Button (new Rect(Screen.width * guiPlacementx2, Screen.height * guiPlacementy2, Screen.width *.25f, Screen.height *.1f),"Quit")){
				Application.Quit();
			}
		}

		else{

			if (GUI.Button (new Rect(Screen.width * guiPlacementx1, Screen.height * guiPlacementy1, Screen.width *.25f, Screen.height *.1f),"",Random1)){
			
			}
		
			if (GUI.Button (new Rect(Screen.width * guiPlacementx2, Screen.height * guiPlacementy2, Screen.width *.25f, Screen.height *.1f),"",Random2)){
			
			}
		}
	}
	
}
