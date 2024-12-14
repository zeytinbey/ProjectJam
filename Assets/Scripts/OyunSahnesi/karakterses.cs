using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterses : MonoBehaviour
{
    public AudioSource sescontrol;
    public AudioClip olumsesi;

    private void Start()
    {
        sescontrol = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "killbox")
        {
            sescontrol.PlayOneShot(olumsesi);
        }
    }


}
