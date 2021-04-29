using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/Burn Object Script")]
public class BurnObjectScript : MonoBehaviour {
	
	public GameObject BurnEffect;

	void OnTriggerEnter(Collider collided)
	{
        Burnable b = collided.GetComponent<Burnable>();
        if (b != null)
		{
            if (BurnEffect != null)
			{
				Instantiate (BurnEffect, collided.transform.position, collided.transform.rotation);
			}
			Destroy (collided.gameObject);
		}
	}
	
}
