using UnityEngine;

public class ZeminSpawn2 : MonoBehaviour
{
    public float maxTime = 1; // Zeminlerin spawnlanma s�resi
    private float timer = 0; // Spawn zamanlay�c�s�

    public GameObject positiveZemin; // Positive zemin prefab'�
    public GameObject negativeZemin; // Negative zemin prefab'�
    public float yukseklik; // Y�ksekli�in rastgele aral���

    private void Start()
    {
        SpawnZemin();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > maxTime)
        {
            SpawnZemin();
            timer = 0;
        }
    }

    private void SpawnZemin()
    {
        // 10 �zerinden bir rastgele de�er al
        int randomValue = Random.Range(1, 11); // 1 dahil, 11 hari�

        GameObject newzemin;

        if (randomValue <= 7)
        {
            // 7/10 olas�l�kla Negative zemin spawnla
            newzemin = Instantiate(negativeZemin);
        }
        else
        {
            // 3/10 olas�l�kla Positive zemin spawnla
            newzemin = Instantiate(positiveZemin);
        }

        // Zemini belirli bir y�kseklikte rastgele konumland�r
        newzemin.transform.position = transform.position + new Vector3(0, Random.Range(-yukseklik, yukseklik), 0);

        // Zemini 15 saniye sonra yok et
        Destroy(newzemin, 15);
    }
}