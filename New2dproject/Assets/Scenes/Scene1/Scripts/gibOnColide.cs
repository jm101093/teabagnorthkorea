using UnityEngine;
using System.Collections;

public class gibOnColide : MonoBehaviour {
	
	public GameObject[] gibs;
	public GameObject[] staticGibs;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter()
	{
		foreach(GameObject gib in gibs)
		{
			Instantiate(gib,transform.position,transform.rotation);
		}
		foreach(GameObject staticGib in staticGibs)
		{
			Instantiate(staticGib,transform.position,transform.rotation);
		}

		Destroy(gameObject);
	}
}
