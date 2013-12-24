using UnityEngine;
using System.Collections;

	public class PlayerAttack : MonoBehaviour {

	public Rigidbody bulletPrefab;
	public Rigidbody grenadePrefab;

// Use this for initialization
// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Z)){
			bulletAttack();	
		}
		if (Input.GetKeyDown(KeyCode.G)){
			grenadeAttack();
		}
		if (Input.GetMouseButtonDown(0)){
			bulletAttack();
		}
	}
	void bulletAttack() {
		WeaponBehavior behavior = WeaponBehaviorFactory.GetWeaponBehavior(WeaponBehaviorEnum.PISTOL);
		behavior.FireWeapon(this, transform, bulletPrefab);
	}
	void grenadeAttack() {
			WeaponBehavior behavior = WeaponBehaviorFactory.GetWeaponBehavior(WeaponBehaviorEnum.GRENADE);
			behavior.FireWeapon(this, transform, grenadePrefab);
	}
}