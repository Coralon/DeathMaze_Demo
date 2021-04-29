using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestChangeTrigger : MonoBehaviour
{
    public QuestGiver QuestNPC;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            QuestNPC.QuestUpdate();

            Destroy(this.gameObject);
        }
    }
}
