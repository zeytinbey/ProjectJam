using UnityEngine;

public class ZeminSpawn2 : MonoBehaviour
{
    public float maxTime = 1; // Zeminlerin spawnlanma süresi
    private float timer = 0; // Spawn zamanlayýcýsý

    public GameObject positiveZemin; // Positive zemin prefab'ý
    public GameObject negativeZemin; // Negative zemin prefab'ý
    public float yukseklik; // Yüksekliðin rastgele aralýðý

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
        // 10 üzerinden bir rastgele deðer al
        int randomValue = Random.Range(1, 11); // 1 dahil, 11 hariç

        GameObject newzemin;

        if (randomValue <= 7)
        {
            // 7/10 olasýlýkla Negative zemin spawnla
            newzemin = Instantiate(negativeZemin);
        }
        else
        {
            // 3/10 olasýlýkla Positive zemin spawnla
            newzemin = Instantiate(positiveZemin);
        }

        // Zemini belirli bir yükseklikte rastgele konumlandýr
        newzemin.transform.position = transform.position + new Vector3(0, Random.Range(-yukseklik, yukseklik), 0);

        // Zemini 15 saniye sonra yok et
        Destroy(newzemin, 15);
    }
}