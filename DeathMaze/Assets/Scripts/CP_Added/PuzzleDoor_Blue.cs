using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor_Blue : MonoBehaviour
{
    public QuestGiver QuestNPC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Statue_1"))
        {
            QuestNPC.QuestUpdate();
            FindObjectOfType<AudioManager>().Play("Unlock");
            //Destroy(this.gameObject);
        }
    }
}
