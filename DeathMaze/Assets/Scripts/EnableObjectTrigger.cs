using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/Enable Object Trigger")]
public class EnableObjectTrigger : MonoBehaviour {
	
		public List<string> TriggerTags = new List<string>();
        public List<GameObject> ObjectsToEnable = new List<GameObject>();
        //public GameObject ObjectToEnable;
		public bool DisableOnTriggerExit = true;
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
                        foreach (GameObject ObjectToEnable in ObjectsToEnable)
                        {
                            ObjectToEnable.SetActive(true);
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
			if(TriggerTags.Count > 0 && DisableOnTriggerExit)
			{
				foreach(string TAG in TriggerTags)
				{ 
					if(collided.gameObject.CompareTag(TAG))
					{
                        foreach (GameObject ObjectToEnable in ObjectsToEnable)
                        {
                            ObjectToEnable.SetActive(false);
                        }
                    }
				}
			}
		}

	}
