using UnityEngine;
using System.Collections;

public class shootRapid : MonoBehaviour {
	
	public GameObject bullet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			if(Input.GetKey(KeyCode.Z))
		{
			Instantiate(bullet,transform.position,transform.rotation);
		}
	}
	
}
