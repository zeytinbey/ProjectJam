using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text hiScoreText;

    public float scoreCount;
    public float hiscoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    private void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            hiscoreCount = PlayerPrefs.GetFloat("HighScore");
        }
   
    }

    private void Update()
    {

        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }        
        if(scoreCount > hiscoreCount)
        {
            hiscoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiscoreCount);
        }
               
        scoreText.text = "Score = " + Mathf.Round (scoreCount);
        hiScoreText.text = "High Score = " + Mathf.Round (hiscoreCount);
    }

    public void AddScore (int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }

}
