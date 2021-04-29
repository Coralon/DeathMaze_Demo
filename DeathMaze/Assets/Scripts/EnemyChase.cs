using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
     GameObject Player;
    Transform PlayerLocation;
   public float MoveSpeed = 4;
    float MaxDist = 10;
    float MinDist = 5;
    public float viewRange = 10;

    // Start is called before the first frame update
    void Start()
    {
       Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLocation = Player.GetComponent<Transform>();

       
            float dist = Vector3.Distance(PlayerLocation.transform.position, transform.position);
        // print("Distance to other: " + dist);

        if (dist < viewRange)
        {
            transform.LookAt(PlayerLocation);

            //  if(Vector3.Distance(transform.position, PlayerLocation.position) >= MinDist) 
            //  {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            // }
        }
            
      

    }
}
