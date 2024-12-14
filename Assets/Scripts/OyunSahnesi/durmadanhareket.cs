using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class durmadanhareket : MonoBehaviour
{
    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpForce;
    
    private float jumpTimeCounter;
    public float jumpTime;

    private Rigidbody2D myRigidbody;

    public bool karakteryerde = true;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    public GameManager theGameManager;

    public GameObject menu;

    public GameObject exit;

    public AudioClip ziplamasound;
    public AudioSource sescontrol;
    public AudioClip inmesound;

    private void Start()
    {
       myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;

        speedMilestoneCountStore = speedMilestoneCount;
    
        sescontrol = GetComponent<AudioSource>();

    }

    private void Update()
    {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        
        myRigidbody.linearVelocity = new Vector2(moveSpeed, myRigidbody.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && karakteryerde == true || Input.GetMouseButtonDown(0) && karakteryerde == true || Input.GetKeyDown(KeyCode.UpArrow) && karakteryerde == true)
        {
            sescontrol.PlayOneShot(ziplamasound);
            
            myRigidbody.linearVelocity = new Vector2(myRigidbody.linearVelocity.x, jumpForce);
            karakteryerde = false;
            
        }


        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            sescontrol.PlayOneShot(inmesound);
            myRigidbody.linearVelocity = -new Vector2(myRigidbody.linearVelocity.y, jumpForce);
        
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            myRigidbody.linearVelocity = new Vector2 (moveSpeed * 1.5f ,myRigidbody.linearVelocity.y);
        }


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {
            Time.timeScale = 0;
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            menu.SetActive(true);
            exit.SetActive(true);
        }
 


        if (other.gameObject.tag == "zemin")
        {
            karakteryerde = true;
        }

       
        if (other.gameObject.tag == "positive")
        {
            
            FindObjectOfType<ScoreManager>().AddScore(1000);

           
        }

     
        if (other.gameObject.tag == "negative")
        {
            
            Debug.Log("Negative platforma çarptýnýz!");
        }


    }



}
