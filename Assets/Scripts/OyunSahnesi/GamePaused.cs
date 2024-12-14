using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePaused : MonoBehaviour
{
    public static bool pause = false;

    public GameObject pauseMenuUI;

    public GameObject optionsMenu;

    public AudioSource pauseSound;
      void Update()
      {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }
      }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }
  
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
        
    }

    public void ShowOptions()
    {
        pause = true;
        optionsMenu.SetActive(true);
        

    }


    public void SetQuality(int qual)
    {
        PlayerPrefs.SetInt("grafik", qual);
        QualitySettings.SetQualityLevel(qual);
    }

    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }

    public void SetMusic(bool music)
    {
        
        
        pauseSound.mute = !music;
    }

}
