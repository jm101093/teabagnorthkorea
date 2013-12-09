using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public Rigidbody bulletPrefab;

	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z)){
			bulletAttack();		
		}
	}

	void bulletAttack() {
		WeaponBehavior behavior = WeaponBehaviorFactory.GetWeaponBehavior(WeaponBehaviorEnum.PISTOL);
		behavior.FireWeapon(this, transform, bulletPrefab);
	}
}
