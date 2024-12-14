using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Mevcut skoru g�stermek i�in
    public Text hiScoreText; // En y�ksek skoru g�stermek i�in
    public Text healthText; // Karakterin can�n� g�stermek i�in

    public float scoreCount; // Mevcut skor
    public float hiscoreCount; // En y�ksek skor

    public float pointsPerSecond; // Skorun saniyede art�� miktar�

    public bool scoreIncreasing; // Skor art��� kontrol�

    public int maxHealth = 4; // Maksimum can
    private int currentHealth; // Mevcut can

    private void Start()
    {
        // Skor ve sa�l�k ba�lang�� de�erleri
        currentHealth = maxHealth;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            hiscoreCount = PlayerPrefs.GetFloat("HighScore");
        }

        UpdateUI();
    }

    private void Update()
    {
        // Skorun zamanla artmas�
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        // Y�ksek skoru kontrol et
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
        // Sa�l�k bir azal�r
        currentHealth--;

        // Sa�l�k s�f�r oldu�unda oyunu durdurabiliriz
        if (currentHealth <= 0)
        {
            GameOver();
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        // UI g�ncellenir
        scoreText.text = "Score = " + Mathf.Round(scoreCount);
        hiScoreText.text = "High Score = " + Mathf.Round(hiscoreCount);
        healthText.text = "Health = " + currentHealth;
    }

    private void GameOver()
    {
        // Oyun bitti�inde yap�lacaklar
        Debug.Log("Game Over!");
        scoreIncreasing = false;
        // �sterseniz oyun durabilir veya men�ye d�nebilir:
        // Time.timeScale = 0;
    }
}