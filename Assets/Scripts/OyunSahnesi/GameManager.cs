using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public durmadanhareket thePlayer;
    private Vector3 playerStartPoint;

    private ScoreManager theScoreManager;

    private void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
      
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;
        
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        
        
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }

}
