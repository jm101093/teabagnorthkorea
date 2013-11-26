using UnityEngine;
using System.Collections;

public class PlayerMouseAim : MonoBehaviour {

	public float mouseCoordinateX = 0.0f;
	public float mouseCoordinateY = 0.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		mouseCoordinateX = Input.mousePosition.x;
		mouseCoordinateY = Input.mousePosition.y;
	}
}
