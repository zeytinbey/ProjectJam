using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Mevcut skoru göstermek için
    public Text hiScoreText; // En yüksek skoru göstermek için
    public Text healthText; // Karakterin canýný göstermek için

    public float scoreCount; // Mevcut skor
    public float hiscoreCount; // En yüksek skor

    public float pointsPerSecond; // Skorun saniyede artýþ miktarý

    public bool scoreIncreasing; // Skor artýþý kontrolü

    public int maxHealth = 4; // Maksimum can
    private int currentHealth; // Mevcut can

    private void Start()
    {
        // Skor ve saðlýk baþlangýç deðerleri
        currentHealth = maxHealth;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiscoreCount = PlayerPrefs.GetFloat("HighScore");
        }

        UpdateUI();
    }

    private void Update()
    {
        // Skorun zamanla artmasý
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        // Yüksek skoru kontrol et
        if (scoreCount > hiscoreCount)
        {
            hiscoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", hiscoreCount);
        }

        UpdateUI();
    }

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }

    public void ReduceHealth()
    {
        // Saðlýk bir azalýr
        currentHealth--;

        // Saðlýk sýfýr olduðunda oyunu durdurabiliriz
        if (currentHealth <= 0)
        {
            GameOver();
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        // UI güncellenir
        scoreText.text = "Score = " + Mathf.Round(scoreCount);
        hiScoreText.text = "High Score = " + Mathf.Round(hiscoreCount);
        healthText.text = "Health = " + currentHealth;
    }

    private void GameOver()
    {
        // Oyun bittiðinde yapýlacaklar
        Debug.Log("Game Over!");
        scoreIncreasing = false;
        // Ýsterseniz oyun durabilir veya menüye dönebilir:
        // Time.timeScale = 0;
    }
}