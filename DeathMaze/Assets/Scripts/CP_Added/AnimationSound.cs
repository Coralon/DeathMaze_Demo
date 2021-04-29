using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSound : MonoBehaviour
{
    public void PlaySoundOpen()
    {
        FindObjectOfType<AudioManager>().Play("OpenDoor");
    }

    public void PlaySoundClose()
    {
        FindObjectOfType<AudioManager>().Play("CloseDoor");
    }
}
