using UnityEngine;
using System.Collections;

public class gibOnColide : MonoBehaviour {
	
	public GameObject[] gibs;
	public GameObject[] staticGibs;

	
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

	}
}
