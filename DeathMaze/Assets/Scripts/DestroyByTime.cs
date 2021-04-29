using UnityEngine;
using System.Collections;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/Destroy By Time")]
public class DestroyByTime : MonoBehaviour {

	public float lifetime = 5;

	void Start ()
	{
		Destroy (gameObject, lifetime);
	}
}
