using UnityEngine;
using System.Collections;

public class grenadeBehavior : MonoBehaviour {

	public AudioClip explode;

	void Start () {
		Object.Destroy(gameObject, 3.5f);

		audio.Play();
		 
	}

}