using UnityEngine;
using System.Collections;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/BulletScript")]
public class BulletScript : MonoBehaviour {

	public GameObject bulletHitParticleEffect;
	public int damageInflicted = 100;


	// Update is called once per frame
	void OnCollisionEnter (Collision other) {

		// Did we shoot a player?
		if (other.gameObject.CompareTag("Player"))
        {
			PlayerInventory changeHealth = other.gameObject.GetComponent<PlayerInventory>();
			changeHealth.changeHealth(damageInflicted);
        }

		// Did we shoot an NPC?
		Shootable shotObject = other.gameObject.GetComponent<Shootable>();
		if(shotObject != null) 
		{
			shotObject.IsShot (damageInflicted);
		}
		if (bulletHitParticleEffect != null) {
			Instantiate (bulletHitParticleEffect, transform.position, transform.rotation);
		}
		Destroy (gameObject);

	}
}
