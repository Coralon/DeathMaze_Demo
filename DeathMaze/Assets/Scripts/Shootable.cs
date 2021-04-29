using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/Shootable")]
public class Shootable : MonoBehaviour {

	public GameObject particleEffectWhenShot;
	public GameObject particleEffectWhenInjured;
	public Slider slider;
	public float delayBeforeDeath = 0;
	public float health = 100;
	public float maxHealth = 250;

	public void IsShot (float damageInflicted) {
		StartCoroutine (Die (damageInflicted));
	}

	IEnumerator Die(float damageInflicted){
		health -= damageInflicted;
		slider.value = health / maxHealth;
		Debug.Log ("Shot object has health of: " + health);
		if (health <= 0) {
			yield return new WaitForSeconds (delayBeforeDeath);
			if (particleEffectWhenShot != null) {			
				Instantiate (particleEffectWhenShot, transform.position, transform.rotation);
			}
			FindObjectOfType<AudioManager>().Play("Explosion");
			DoorLock doorLocked = GameObject.Find("DoorTrigger (4)").GetComponent<DoorLock>();
			doorLocked.locked = false;
			Destroy (gameObject);
		}
		if ((health > 0) && (particleEffectWhenInjured != null)) {
			Instantiate (particleEffectWhenInjured, transform.position, transform.rotation);
		}
		yield return null;
	}
}
