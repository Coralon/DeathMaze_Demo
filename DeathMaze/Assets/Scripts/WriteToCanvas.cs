using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/Write To Canvas")]
public class WriteToCanvas : MonoBehaviour {

	public List<string> TriggerTags = new List<string>();
	public GameObject CanvasTextObject;
	public string TextToDisplay;
	public bool clearTextOnExit;

	//
	void OnTriggerEnter(Collider collided)
	{
		if(TriggerTags.Count > 0)
		{
			foreach(string TAG in TriggerTags)
			{ 
				if(collided.gameObject.CompareTag(TAG))
				{
					if (CanvasTextObject != null)
					{
						Text text = CanvasTextObject.GetComponent<Text> ();
						text.text = TextToDisplay;
					}
					if (CanvasTextObject == null)
					{
						Debug.Log("Trigger activated but no Canvas Text Game Object specified");
					}
				}
			}
		}
	}
	void OnTriggerExit(Collider collided)
	{
		if((TriggerTags.Count > 0) && clearTextOnExit)
		{
			foreach(string TAG in TriggerTags)
			{ 
				if(collided.gameObject.CompareTag(TAG))
				{
					if (CanvasTextObject != null)
					{
						Text text = CanvasTextObject.GetComponent<Text> ();
						//text.text = TextToDisplay;
						text.text = (" ");
					}
					if (CanvasTextObject == null)
					{
						Debug.Log("Trigger activated but no Canvas Text Game Object specified");
					}
				}
			}
		}
	}
	//
}
