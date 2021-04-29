using UnityEngine;
using System.Collections;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/Door")]
public class Door : MonoBehaviour {

    public float xMovement;
    public float yMovement;
    public float zMovement;
    public float speed = 3.0f;
    Vector3 targetTransform;
    Vector3 initialTransform;

	// Use this for initialization
	void Start () {
        targetTransform = transform.position;
        initialTransform = transform.position;
	}

    void Update ()
    {
        if (transform.position != targetTransform)
        {
            float step = speed * Time.deltaTime;
            Debug.Log("Moving Door");
            transform.position = Vector3.MoveTowards(transform.position, targetTransform, step);
        }
    }

    public void OpenDoor()
    {
        targetTransform = initialTransform + new Vector3(xMovement, yMovement, zMovement);
    }

    public void CloseDoor()
    {
        targetTransform = initialTransform;
    }

}
