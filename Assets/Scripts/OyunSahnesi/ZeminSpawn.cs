using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeminSpawn : MonoBehaviour
{
    public float maxTime = 1;
    public float timer = 0;
    public GameObject zemin;
    public float yukseklik;

    private void Start()
    {
        GameObject newzemin = Instantiate(zemin);
        newzemin.transform.position = transform.position + new Vector3(0, Random.Range(-yukseklik, yukseklik),0);
    }

    private void Update()
    {
        if(timer > maxTime)
        {
            GameObject newzemin = Instantiate(zemin);
            newzemin.transform.position = transform.position + new Vector3(0, Random.Range(-yukseklik, yukseklik), 0);
            Destroy(newzemin, 15);
            timer = 0;
        }
        timer += Time.deltaTime;
        
    }
}
