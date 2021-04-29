using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/Trigger Teleportation Simple")]
public class TriggerTeleportationSimple : MonoBehaviour 
{
	public List<string> TriggerTags = new List<string>();
	public Transform Destination;
	
	// Use this for initialization
	void Start () 
	{
		if (Destination == null)
		{
			Debug.Log("Please specify where objects should be teleported by dragging a gameobject into the Destination slot");
		}
	}


	
	void OnTriggerEnter(Collider collided)
	{
		if(TriggerTags.Count > 0)
		{
			foreach(string TAG in TriggerTags)
			{ 
				if(collided.gameObject.CompareTag(TAG))
				{
					//Debug.Log("Here");
  					collided.transform.position = Destination.position;
					collided.transform.rotation = Destination.rotation;
					break;
				}
			}
		}
		else
		{
			collided.transform.position = Destination.position;
		}
	}
}
