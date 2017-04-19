using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy : MonoBehaviour, IDamageable {

	[SerializeField] float maxHealthPoints = 100f;
	[SerializeField] float attackRadius = 4f;
	[SerializeField] float chaseRadius = 6f;
	[SerializeField] float damagePerShot = 9f;
	[SerializeField] GameObject projectileToUse;
	[SerializeField] GameObject projectileSocket;

	GameObject player = null;
	AICharacterControl AIcharacterControl = null;
	float currentHealthPoints = 100f;


	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player");
		AIcharacterControl = GetComponent<AICharacterControl> ();
	}

	void Update () {
		float distanceToPlayer = Vector3.Distance (player.transform.position, transform.position);

		if (distanceToPlayer <= attackRadius) {
			SpawnProjectile ();
		}

		if (distanceToPlayer <= chaseRadius) {
			AIcharacterControl.SetTarget (player.transform);
		} else {
			
			AIcharacterControl.SetTarget (transform);
		}
	}

	void SpawnProjectile() {
		GameObject newSpear = Instantiate (projectileToUse, projectileSocket.transform.position, Quaternion.identity);
	}


	public float healthAsPercentage {
		get {
			
		return currentHealthPoints / maxHealthPoints;
		}
	}

	public void TakeDamage(float damage) {
		currentHealthPoints = Mathf.Clamp (currentHealthPoints - damage, 0f, maxHealthPoints);
	}

	void OnDrawGizmos() {

		//draw attack sphere
		Gizmos.color = new Color(255f,0f,0f,.5f);
		Gizmos.DrawWireSphere (transform.position, attackRadius);

		//draw chase sphere
		Gizmos.color = new Color(0f,0f,255f,.5f);
		Gizmos.DrawWireSphere (transform.position, chaseRadius);

	}
}
