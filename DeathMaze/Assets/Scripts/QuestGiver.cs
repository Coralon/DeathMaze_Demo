using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{

    public bool inRange = false;
    public GameObject[] QuestList;
    int currentQuestNum;
   [HideInInspector] public GameObject QuestText;

    // Start is called before the first frame update
    void Start()
    {
        foreach ( GameObject quest in QuestList)
        {
            quest.SetActive(false);
        }

        QuestText = QuestList[0];
        currentQuestNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
      //  if (inRange && Input.GetKeyDown(KeyCode.E))
      if (inRange)
        {
            QuestText.SetActive(true);
        }

      if (Input.GetKeyDown(KeyCode.E))
        {
        //    QuestUpdate();
        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = false;
            QuestText.SetActive(false);
        }
    }

    public void QuestUpdate()
    {
        // Turn current QuestText off
        QuestText.SetActive(false);

        // Change QuestText
        if (currentQuestNum < QuestList.Length && QuestList[currentQuestNum] != null)
        {
            //Debug.Log("Change Quest");
            currentQuestNum ++;
            //Debug.Log("Current Step " + currentQuestNum);
            QuestText = QuestList[currentQuestNum];
            if (currentQuestNum == QuestList.Length - 1)
            {
                DoorLock doorLocked = GameObject.Find("PuzzleDoor").GetComponent<DoorLock>();
                doorLocked.locked = false;
            }
        }

    }
}
