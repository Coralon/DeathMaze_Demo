using UnityEngine;
using System.Collections;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/EnemyFire")]
public class EnemyFire : MonoBehaviour {
	//public GameObject enemy;
	public GameObject barrel;
	public float firingRange = 20.0f;
	public float bulletSpeed;
	private float shootTime = 0.0f;
	public float shotInterval = 0.2f; // interval between shots
	public Rigidbody bulletPrefab; // drag the bullet prefab heree;
	Ray ray;
	RaycastHit hit;

	void Update () {

		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out hit, firingRange)) {
			if (hit.collider.gameObject.tag == "Player") {
				if (Time.time >= shootTime) { // if it's time to shoot...
					Rigidbody bullet = (Rigidbody)Instantiate (bulletPrefab, barrel.transform.position, barrel.transform.rotation);
					bullet.AddForce (transform.forward * bulletSpeed); // shoot in the target direction
					shootTime = Time.time + shotInterval; // set time for next shot
					FindObjectOfType<AudioManager>().Play("GunFire");
				}
				// add rotation toward the player
				/*
				Vector3 lookDirection = (hit.collider.attachedRigidbody.position - transform.position).normalized;
				Rigidbody enemyRb = GetComponent<Rigidbody>();
				enemyRb.transform.Rotate(transform.rotation.x, lookDirection.y, lookDirection.z);
				//enemyRb.transform.Rotate(lookDirection);
				Debug.Log(lookDirection);
				*/
			}
		}
	}

	void BulletFire() {
		Instantiate (bulletPrefab, barrel.transform.position, transform.rotation);
		bulletPrefab.GetComponent<Rigidbody> ().AddForce (bulletPrefab.transform.forward * bulletSpeed);
	}
}

