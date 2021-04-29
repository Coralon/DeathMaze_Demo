using UnityEngine;
using System.Collections;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/ChangePlayerInventory")]
public class ChangePlayerInventory : MonoBehaviour {

    public int healthGiven;
    public int pointsGiven;
    public bool giveKey;
    bool alreadyCollected = false;
    public GameObject collectParticleEffect;

    void OnTriggerEnter(Collider other)
    {
        PlayerInventory hitPlayer = other.gameObject.GetComponent<PlayerInventory>();
        if ((hitPlayer != null) && (!alreadyCollected))
        {
            if (healthGiven != 0)
            {
                hitPlayer.changeHealth(healthGiven);
            }
            if (pointsGiven != 0)
            {
                hitPlayer.changePoints(pointsGiven);
            }
            if (giveKey)
            {
                hitPlayer.hasKey = true;
            }
            alreadyCollected = true;
            StartCoroutine (Collected());
        }
    }

    IEnumerator Collected()
    {
        {
            AudioSource audio = GetComponent<AudioSource>();
            if (collectParticleEffect != null)
            {
                Instantiate(collectParticleEffect, transform.position, transform.rotation);
            }
            if ((audio != null) && audio.clip != null)
            {
                audio.Play();
                yield return new WaitForSeconds(audio.clip.length);
            }
            Destroy(gameObject);
        }
        yield return null;
    }

}
