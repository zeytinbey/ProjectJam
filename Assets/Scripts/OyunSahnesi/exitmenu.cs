using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitmenu : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
}
