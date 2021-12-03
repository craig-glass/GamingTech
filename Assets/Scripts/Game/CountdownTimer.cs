using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float timeLeft;
    public bool countdownRunning = false;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = GameManager.Instance.countdownTime;
        countdownRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownRunning)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                DisplayTime(timeLeft);
            }
            else
            {
                Debug.Log("No time left!");
                timeLeft = 0;
                countdownRunning = false;
            }
        }
    }

    public void DisplayTime(float time)
    {
        time += 1;

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }
}
