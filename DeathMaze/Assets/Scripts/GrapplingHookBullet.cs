using UnityEngine;
using System.Collections;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/GrapplingHookBullet")]
public class GrapplingHookBullet : MonoBehaviour {

	public GameObject bulletHitParticleEffect;
	public int damageInflicted = 100;
	public float moveSpeed = 50.0f;
	GameObject PlayerObject;
	ConfigurableJoint grappleJoint;
	Rigidbody playerRB;
	bool ReadyToPull = false;
	public float snapDistance = 100.0f;
	public bool onlySpecifiedSurfaces = false;
	public float speedMultiplier = 1.0f;
	LineRenderer ropeLine;

	void Start ()
	{
		PlayerObject = GameObject.FindWithTag ("Player");
		grappleJoint = gameObject.GetComponent<ConfigurableJoint> ();
		playerRB = PlayerObject.GetComponent<Rigidbody> ();
		grappleJoint.connectedBody = playerRB;
		StartCoroutine (CheckDistance ());
		ropeLine = gameObject.GetComponent<LineRenderer> ();
		if (ropeLine != null) 
		{
			ropeLine.useWorldSpace = true;
		}
		ropeLine.material = new Material (Shader.Find ("Particles/Standard Unlit"));
	}

	void Update ()
	{
		if ((Input.GetMouseButtonDown (1)) || (Input.GetMouseButtonDown (0)) ||  (Input.GetKeyDown ("f"))) 
		{
			Destroy (gameObject);
		}
		if ((Input.GetButtonDown("Jump")) && ReadyToPull)
		{
			ReadyToPull = false;
			StartCoroutine (GrapplePlayer ());
		}
		LineRenderer ropeLine = gameObject.GetComponent<LineRenderer> ();
		if (ropeLine != null) 
		{
			ropeLine.SetPosition (0, PlayerObject.transform.position);
			ropeLine.SetPosition (1, transform.position);
		}
	}

	IEnumerator CheckDistance()
	{
		while (true) 
		{
			Vector3 playerToHook = PlayerObject.transform.position - transform.position;
			if (playerToHook.magnitude >= snapDistance) 
			{
				Destroy (gameObject);
			}
			yield return new WaitForSeconds (0.25f);
		}
	}
		
	
	// Update is called once per frame
	void OnCollisionEnter (Collision other) {
		GrappleSurface grappleObject = other.gameObject.GetComponent<GrappleSurface> ();
		if (bulletHitParticleEffect != null) {
			Instantiate (bulletHitParticleEffect, transform.position, transform.rotation);
		}
		if (grappleObject == null) 
		{
			Destroy (gameObject);	
		} else
        {
			FindObjectOfType<AudioManager>().Play("GrapplingHookHit");
		}
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;
		ropeLine.SetColors (Color.green, Color.green);
		ReadyToPull = true;
		FindObjectOfType<AudioManager>().Play("GrapplingHookHit");
	}

	IEnumerator GrapplePlayer()
	{
		Vector3 playerToHook = PlayerObject.transform.position - transform.position;
		SoftJointLimit limits = grappleJoint.linearLimit;
		limits.limit = playerToHook.magnitude;
		grappleJoint.linearLimit = limits;
		while (playerToHook.magnitude >= 1) 
		{
			yield return new WaitForEndOfFrame();
			limits.limit = (grappleJoint.linearLimit.limit - (grappleJoint.linearLimit.limit * Time.deltaTime * speedMultiplier));
			grappleJoint.linearLimit = limits;
			//recalculate vector from player to the hook to decide if while loop should continue
			playerToHook = PlayerObject.transform.position - transform.position;
		}
		grappleJoint.connectedBody = null;
		yield return null;
		Destroy (gameObject);
	}
		
}
