using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/Disable Object Trigger")]
public class DisableObjectTrigger : MonoBehaviour {
	
		public List<string> TriggerTags = new List<string>();
        public List<GameObject> ObjectsToDisable = new List<GameObject>();
        //public GameObject ObjectToEnable;
		public bool EnableOnTriggerExit = true;
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
                        foreach (GameObject ObjectToDisable in ObjectsToDisable)
                        {
                            ObjectToDisable.SetActive(false);
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
			if(TriggerTags.Count > 0 && EnableOnTriggerExit)
			{
				foreach(string TAG in TriggerTags)
				{ 
					if(collided.gameObject.CompareTag(TAG))
					{
                        foreach (GameObject ObjectToEnable in ObjectsToDisable)
                        {
                            ObjectToEnable.SetActive(true);
                        }
                    }
				}
			}
		}

	}
