using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("AIE Scripts/IntroToGameDesignShortCourse/PlayerFire")]
public class PlayerFire : MonoBehaviour {

	GameObject MainCamera;
	public Transform barrel;
	public float bulletSpeed;
	private float shootTime = 0.0f;
	public float shotInterval = 0.2f; // interval between shots
	public Rigidbody bulletPrefab; // drag the bullet prefab heree;
	public List<Rigidbody> bulletPrefabs = new List<Rigidbody>();
	public int currentWeaponNum = 0;

	public bool allowWeaponChanging = false;
	public bool inheritVelocity = false;
	public bool ignoreCollisionWithPlayer = false;
	public bool canFire = false;


	void Start () {
		if (bulletPrefab == null)
		{
			Debug.Log("No projectile prefab selected.  Please drag a gameobject into the barrel slot");
		}
        if (barrel == null)
        {
            barrel = transform;
        }
		MainCamera = GameObject.FindWithTag ("MainCamera");
	}

    void Update()
    {
		if ((Input.GetKeyDown ("g")) && allowWeaponChanging)
		{
			Debug.Log ("changing to next weapon");
			currentWeaponNum += 1;
			if (currentWeaponNum >= bulletPrefabs.Count) 
			{
				currentWeaponNum = 0;
			}
			bulletPrefab = bulletPrefabs [currentWeaponNum];
		}

		if (canFire)
        {
			if ((Input.GetMouseButtonDown(0)) || (Input.GetKeyDown("f")) && (bulletPrefab != null) && (Time.time >= shootTime))
			{
				Rigidbody bullet = (Rigidbody)Instantiate(bulletPrefab, barrel.position, MainCamera.transform.rotation);
				if (ignoreCollisionWithPlayer)
				{
					Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
				}
				if (inheritVelocity)
				{
					bullet.velocity = GetComponent<Rigidbody>().velocity;
				}
				//Vector3 localForward = Vector3.forward;
				//bullet.AddForce (transform.forward * bulletSpeed); // shoot in the target direction
				bullet.AddForce(MainCamera.transform.forward * bulletSpeed); // shoot in the target direction
																			 //bullet.AddForce (transform.TransformDirection (localForward) * bulletSpeed); // shoot in the target direction
				shootTime = Time.time + shotInterval; // set time for next shot
				if (currentWeaponNum == 1)
                {
					FindObjectOfType<AudioManager>().Play("GunFire");
					//Debug.Log(currentWeaponNum);
				}
				if (currentWeaponNum == 0)
                {
					FindObjectOfType<AudioManager>().Play("GrapplingHookFire");
				}

			}
		}
        
    }

}

