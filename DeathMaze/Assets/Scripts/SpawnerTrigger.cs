using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/Spawner Trigger")]
public class SpawnerTrigger : MonoBehaviour {
	
	public List<string> TriggerTags = new List<string>();
	private string DestroyWithThisTag;
	private GameObject ObjectToDestroy;
	public GameObject SpawnObject;
	public Transform SpawnPosition;
	public bool AllowMultipleObjects = false;
	public bool TriggersOnceOnly = false;
	private bool HasAlreadyBeenTriggered = false;

	void OnTriggerEnter(Collider collided)
	{
		if(TriggerTags.Count > 0 && !HasAlreadyBeenTriggered)
		{
			foreach(string TAG in TriggerTags)
			{ 
				if(collided.gameObject.CompareTag(TAG))
				{
					ObjectToDestroy = GameObject.FindWithTag (DestroyWithThisTag);
					if (ObjectToDestroy != null && !AllowMultipleObjects)
					{
					Destroy (ObjectToDestroy);
					}
					Instantiate (SpawnObject, SpawnPosition.transform.position, SpawnPosition.transform.rotation);
					if (TriggersOnceOnly)
					{
						HasAlreadyBeenTriggered = true;
					}
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		if (SpawnObject == null)
		{
			Debug.Log("Please specify what object this script should spawn in the SpawnObject slot");
		}
		if (SpawnPosition == null)
		{
			Debug.Log("Please specify where objects should be spawned by dragging a gameobject into the SpawnPosition slot");
		}
		if (TriggerTags.Count == 0) 
		{
			Debug.Log ("GameObject " + gameObject + " has no trigger tags set - nothing can ever trigger it!");
		}
		DestroyWithThisTag = SpawnObject.tag;
	}
	

}
