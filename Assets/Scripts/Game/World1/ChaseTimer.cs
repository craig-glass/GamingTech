using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChaseTimer : MonoBehaviour
{
    float timeGone;
    public TMP_Text timeText;


    // Start is called before the first frame update
    void Start()
    {
        timeGone = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (World1State.chaseTimerRun)
        {
            Debug.Log(Time.deltaTime);
            timeGone += Time.deltaTime;
            timeText.text = "Chase Is On!!\n";
            DisplayTime(timeGone);
        }
        else
        {
            if (timeGone > World1State.longestChase)
            {
                World1State.longestChase = timeGone;
            }
            timeGone = 0;
            timeText.text = "";

           
        }
        
    }

    public void DisplayTime(float time)
    {
        time += 1;

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timeText.text += string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
