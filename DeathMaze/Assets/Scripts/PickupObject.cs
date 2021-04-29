using UnityEngine;
using System.Collections;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/Pickup Object")]
public class PickupObject : MonoBehaviour {

	GameObject mainCamera;
	bool carrying;
	GameObject carriedObject;
	public float distance = 3.0f;
	public float smooth = 10.0f;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        if (carrying && (carriedObject == null))
        {
            carrying = false;
        }
		if (carrying) {
			Carry (carriedObject);
			CheckDrop();
		} else {
			Pickup ();
		}
	}
	//void RotateObject() {
	//	carriedObject.transform.Rotate (5, 10, 5);
	//}

	void Carry(GameObject obj) {
		obj.transform.position = Vector3.Lerp(obj.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
		// stop picked up object rotating
		obj.transform.rotation = Quaternion.identity;
		//obj.transform.rotation = mainCamera.transform.rotation;
	}

	void Pickup() {
		if (Input.GetKeyDown (KeyCode.E)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Pickupable p = hit.collider.GetComponent<Pickupable>();
				if((p != null) && hit.distance <= 4) {
					carrying = true;
					carriedObject = p.gameObject;
					carriedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
					p.gameObject.GetComponent<Rigidbody>().useGravity = false;
				}
			}

		}
	}

	void CheckDrop() {
		if (Input.GetKeyDown (KeyCode.E)) {
			DropObject();
		}
	}

	void DropObject() {
		carrying = false;
		carriedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		carriedObject.GetComponent<Rigidbody>().useGravity = true;
		carriedObject = null;
	}
}
