using UnityEngine;
using System.Collections;

public class LockPlayerToPlatform : MonoBehaviour {

	public GameObject platform;
	private GameObject playerObject;
	public bool lockPlayerInPosition = false;
	public GameObject lockPoint;

	void OnTriggerEnter (Collider other)
	{
		if (lockPlayerInPosition) {
			other.transform.parent = platform.transform;
			lockPoint.transform.position = other.transform.position;
			playerObject = other.gameObject;
			StartCoroutine (LockPlayerPosition ());
		} 
		else 
		{
			other.transform.parent = platform.transform;
		}

	}

	IEnumerator LockPlayerPosition ()
	{
		while (true)
		{
			playerObject.transform.position = lockPoint.transform.position;
			yield return null;
		}
	}


	void OnTriggerExit (Collider other)
	{
		other.transform.parent = null;
	}
}
