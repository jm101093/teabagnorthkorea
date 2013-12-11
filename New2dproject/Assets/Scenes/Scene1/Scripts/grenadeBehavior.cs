using UnityEngine;
using System.Collections;

public class grenadeBehavior : MonoBehaviour {

	public AudioClip explode;

	void Start() {
		StartCoroutine(WaitAndPrint(3.2f));
		Object.Destroy(gameObject, 3.5f);
		 
	}
	IEnumerator WaitAndPrint(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		audio.Play();
		print("WaitAndPrint " + Time.time);
	}

}