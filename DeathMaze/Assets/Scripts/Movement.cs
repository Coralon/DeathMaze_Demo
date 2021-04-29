using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 MovementOffset;
    public bool MoveFromStart = true;
    bool MovementCompleted = false;
    public float TimeTaken = 2;
    public float MovementSpeed = 2;


    Vector3 SetPosition;
    Vector3 OriginalPosition;
    float TimeCounter;
    bool TimerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        SetPosition = transform.position + MovementOffset;
        OriginalPosition = transform.position;
        TimeCounter = TimeTaken;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveFromStart && !MovementCompleted)
        {
            //  this.gameObject.transform.position = this.gameObject.transform.position + MovementOffset;
            //  transform.Translate(SetPosition * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, SetPosition, MovementSpeed * Time.deltaTime);

            TimerOn = true;
        }

        if (MovementCompleted)
        {
            transform.position = Vector3.MoveTowards(transform.position, OriginalPosition, MovementSpeed * Time.deltaTime);
            TimerOn = true;
        }

        if (TimerOn && !MovementCompleted)
        {
            TimeCounter -= Time.deltaTime;

            if (TimeCounter < 0)
            {
                MovementCompleted = true;
                TimerOn = false;
                TimeCounter = TimeTaken;
            }
        }

        if (TimerOn && MovementCompleted)
        {
            TimeCounter -= Time.deltaTime;

            if (TimeCounter < 0)
            {
                MovementCompleted = false;
                TimerOn = false;
                TimeCounter = TimeTaken;
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            other.transform.parent = null;
        }
    }

    void OnDrawGizmosSelected()
    {
#if UNITY_EDITOR

        // Draw a yellow cube at the transform position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(OriginalPosition, new Vector3(1, 1, 1));
        Gizmos.DrawWireCube(SetPosition, new Vector3(1, 1, 1));


#endif
    }
}