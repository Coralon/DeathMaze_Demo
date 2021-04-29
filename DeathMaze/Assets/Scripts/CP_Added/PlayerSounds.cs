using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] footstepSounds;    // an array of footstep sounds that will be randomly selected from.
    [SerializeField] private AudioClip jumpSound;           // the sound played when character leaves the ground.
    [SerializeField] private AudioClip landSound;           // the sound played when character touches back on ground.
    private AudioSource audioSource;
    private float stepCycle;
    private float nextStep;
    private float stepInterval;
    private bool wasJumping;
    //[Range(0f,1f)] private float runStep;

    private bool playerGrounded;
    private bool playerRunning;
    private bool playerJumping;
    private Vector3 playerVelocity;

    private bool characterController;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        stepCycle = 0f;
        nextStep = stepCycle / 2f;
        stepInterval = 1f;
        wasJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerGrounded)
        {
            wasJumping = true;
            PlayJumpSound();
            //PlayLandingSound();
        }

        
    }

    private void FixedUpdate()
    {
        // Get the player state
        UpdatePlayerState();

        // Is the player Moving
        if (playerVelocity != new Vector3(0, 0, 0))
        {
            ProgressStepCycle();
        }

        if (playerGrounded && wasJumping)
        {
            //Debug.Log("Player Landing " + playerGrounded);
            wasJumping = false;
            StartCoroutine(PlayLandingSound());
        }


    }

    private void ProgressStepCycle()
    {

        stepCycle += 3 * (playerRunning ? 1.5f : 1f) * Time.fixedDeltaTime;
        //Debug.Log(runStep);
        
        if (!(stepCycle > nextStep))
        {
            return;
        }
        
        nextStep = stepCycle + stepInterval;

        PlayFootStepAudio();
    }

    private void PlayFootStepAudio()
    {
        if (!playerGrounded)
        {
            return;
        }
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, footstepSounds.Length);
        audioSource.clip = footstepSounds[n];
        audioSource.PlayOneShot(audioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        footstepSounds[n] = footstepSounds[0];
        footstepSounds[0] = audioSource.clip;
    }

    private void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
        //Debug.Log("Jumping" + Time.time);
    }

    IEnumerator PlayLandingSound()
    {
        if (playerGrounded)
        {
            yield return new WaitForSeconds(1f);
            audioSource.PlayOneShot(landSound);
            //Debug.Log("Landing" + Time.time + " " + playerGrounded);
        }
    }

    private void UpdatePlayerState()
    {
        playerGrounded = GetComponent<RigidbodyFirstPersonController>().Grounded;
        playerRunning = GetComponent<RigidbodyFirstPersonController>().Running;
        playerJumping = GetComponent<RigidbodyFirstPersonController>().Jumping;
        playerVelocity = GetComponent<RigidbodyFirstPersonController>().Velocity;
    }
}
