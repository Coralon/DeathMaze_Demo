using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorFunctions : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	public bool disableOnce;
	public int currentIndex;

	void ButtonPress()
    {
		if (currentIndex == 0)
        {
			LevelLoader load = FindObjectOfType<LevelLoader>();
			load.LoadNextLevel();
		} else if (currentIndex == 1)
        {
			Application.Quit();
        }
    }
	void PlaySound(AudioClip whichSound){
		if(!disableOnce){
			menuButtonController.audioSource.PlayOneShot (whichSound);
		}else{
			disableOnce = false;
		}
	}
}	
