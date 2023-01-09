using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScriptWanted : MonoBehaviour
{
    public float timer = 40;

    public TextMesh textTimer;


    void Update()
    {

        if (timer <= 0)
        {
            timer = 0;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        textTimer.text = "Time: " + timer.ToString("f0");


    }

    public float getTimer()
    {
        return timer;
    }
}
