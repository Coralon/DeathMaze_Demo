using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/Player Death Trigger")]
public class PlayerDeathTrigger : MonoBehaviour {
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			// Player entered red zone, reload game.
			//Application.LoadLevel(Application.loadedLevel);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
