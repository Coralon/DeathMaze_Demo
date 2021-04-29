using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text currentScoreDisplay;

    public float score = 0;
    public float[] scoreGoal;
    int currentGoalNum;

    public QuestGiver QuestNPC;
    bool questUpdated = false;

    // This is intended to be used with the QuestGiver script. Sends message to that script to update text.

    // Start is called before the first frame update
    void Start()
    {
        currentGoalNum = 0;
        currentScoreDisplay.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {


        if (score >= scoreGoal[currentGoalNum] && !questUpdated)
        {
            QuestNPC.QuestUpdate();
            questUpdated = true;

            if (scoreGoal[currentGoalNum + 1] != null)
            {
                currentGoalNum = currentGoalNum + 1;

                NewGoalCheck();
            }
        }


    }

    public void ScoreUpdate()
    {
        score = score + 1;
        currentScoreDisplay.text = score.ToString();
    }

    void NewGoalCheck()
    {
        if (score < scoreGoal[currentGoalNum])
        {

            questUpdated = false;
        }
    }

}
