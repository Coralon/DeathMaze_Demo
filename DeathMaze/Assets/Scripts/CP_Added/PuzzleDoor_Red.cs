using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor_Red : MonoBehaviour
{
    public QuestGiver QuestNPC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Statue_2"))
        {
            QuestNPC.QuestUpdate();
            FindObjectOfType<AudioManager>().Play("Unlock");
            //Destroy(this.gameObject);
        }
    }
}
