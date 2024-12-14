using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geri_Sayac : MonoBehaviour
{
    public float timeRemaining = 10;

    public bool timerIsRunning = false;

    private void Start()

    {

        Time.timeScale = 0;

        timerIsRunning = true;

    }

    void Update()

    {

        if (timerIsRunning)

        {

            if (timeRemaining > 0)

            {

                timeRemaining -- ;

            }

       if(timeRemaining == 0)
            {
                Time.timeScale = 1;
            }




        }
    }
    }