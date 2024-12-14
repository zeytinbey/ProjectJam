using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeminHareket : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
