using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour
{

    public GameObject infoo;

    public float timeRemaining = 10;

    public bool timerIsRunning = false;

    private void Start()
    {


        timerIsRunning = true;

    }
    void Update()
    {

        if (timerIsRunning)

        {

            if (timeRemaining > 0)

            {

                timeRemaining--;

            }
             else
            {

                Destroy(infoo);

            }

        }

    }
}