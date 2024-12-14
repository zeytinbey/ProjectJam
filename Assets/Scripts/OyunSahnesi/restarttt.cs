using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restarttt : MonoBehaviour
{
    public void Update()
    {   // Reset game on "r" press
      
        
            if (Input.GetKeyDown("r"))
            {
                Time.timeScale = 1f;

                Retry();
            }
        

         void Retry()
        {
            //Restarts current level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}