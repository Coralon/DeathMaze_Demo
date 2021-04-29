using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/DoorTrigger")]
public class DoorTrigger : MonoBehaviour {

    public bool requiresKey;
    public bool TriggersOnceOnly = false;
    public bool CloseOnExit = true;
    bool HasAlreadyBeenTriggered = false;
    public List<string> TriggerTags = new List<string>();
    public List<GameObject> DoorsToTrigger = new List<GameObject>();

    void OnTriggerEnter(Collider collided)
    {
        if ((TriggerTags.Count > 0) && !HasAlreadyBeenTriggered)
        {
            foreach (string TAG in TriggerTags)
            {
                if (collided.gameObject.CompareTag(TAG))
                {
                    PlayerInventory playerInventory = collided.gameObject.GetComponent<PlayerInventory>();
                    foreach (GameObject DoorToTrigger in DoorsToTrigger)
                    {
                        if ((requiresKey && playerInventory.hasKey) || !requiresKey)
                        {
                            Door door = DoorToTrigger.GetComponent<Door>();
                            if (door != null)
                            {
                                Debug.Log("Triggering Door");
                                door.OpenDoor();
                            }
                        }
                    }
                    if (TriggersOnceOnly)
                    {
                        HasAlreadyBeenTriggered = true;
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider collided)
    {
        if ((TriggerTags.Count > 0) && CloseOnExit)
        {
            foreach (string TAG in TriggerTags)
            {
                if (collided.gameObject.CompareTag(TAG))
                {
                    PlayerInventory playerInventory = collided.gameObject.GetComponent<PlayerInventory>();
                    foreach (GameObject DoorToTrigger in DoorsToTrigger)
                    {
                        if ((requiresKey && playerInventory.hasKey) || !requiresKey)
                        {
                            Door door = DoorToTrigger.GetComponent<Door>();
                            if (door != null)
                            {
                                door.CloseDoor();
                            }
                        }
                    }
                }
            }
        }
    }

}
