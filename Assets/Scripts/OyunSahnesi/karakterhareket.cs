using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterhareket : MonoBehaviour
{
    public float yatayhareket;
    public int harekethizi;
    public int ziplamahizi;

    public bool karakteryerde = true;

    public bool faceright = true;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        yatayhareket = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(yatayhareket * harekethizi * 100 * Time.deltaTime, rb.linearVelocity.y);
       
        if (Input.GetKeyDown(KeyCode.Space) && karakteryerde == true || Input.GetKeyDown(KeyCode.W) && karakteryerde == true || Input.GetKeyDown(KeyCode.UpArrow) && karakteryerde == true)
        {
            rb.linearVelocity = Vector2.up * ziplamahizi * 100 * Time.deltaTime;
            karakteryerde = false;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.linearVelocity = Vector2.down * ziplamahizi * 100 * Time.deltaTime;
        }

        if (yatayhareket > 0 && faceright == false)
        {
            turn();
        }

        if (yatayhareket < 0 && faceright == true)
        {
            turn();
        }

    }

    private void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.tag == "zemin")
        {
            karakteryerde = true;
        }
    }

    void turn()
    {
        faceright = !faceright;

        Vector2 yeniscale = transform.localScale;
        yeniscale.x *= -1;
        transform.localScale = yeniscale;
    }

}
