using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

	public GameObject objectToDestroy;

	void OnTriggerEnter()
	{
		Destroy (objectToDestroy);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
