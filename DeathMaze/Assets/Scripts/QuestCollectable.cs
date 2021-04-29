using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCollectable : MonoBehaviour
{


    // This script is intended to be used with the 'Score" and "QuestGiver" scripts.

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<Score>().ScoreUpdate();
            Destroy(this.gameObject);
        }
    }
}
