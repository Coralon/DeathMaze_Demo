using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject instructions;
    public GameObject lockedDoorUI;
    //private DoorLock doorLocked;
    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Door")
        {
            instructions.SetActive(true);
            Animator anim = other.GetComponentInChildren<Animator>();
            DoorLock doorLocked = other.GetComponent<DoorLock>();

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (doorLocked.locked == false)
                {
                    anim.SetTrigger("OpenClose");
                } 
                else
                {
                    lockedDoorUI.SetActive(true);
                }
                
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            instructions.SetActive(false);
            lockedDoorUI.SetActive(false);
        }
    }
}
