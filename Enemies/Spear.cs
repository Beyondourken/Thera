using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour {
	[SerializeField] float projectileSpeed = 10f;
	float damageCaused = 10f;
	void OnTriggerEnter(Collider collider) {


		Component damageableComponent = collider.gameObject.GetComponent (typeof(IDamageable));
		if (damageableComponent) {
			(damageableComponent as IDamageable).TakeDamage (damageCaused);
		}
	}
}
