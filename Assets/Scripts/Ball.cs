<<<<<<< HEAD
﻿using System.Collections;
=======
﻿#pragma warning disable 0649

using System.Collections;
>>>>>>> master
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
<<<<<<< HEAD

    public Rigidbody2D rb;
    public bool isPlay; // game state: if the ball is playing
    public Transform paddle; //get the paddle position
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        // Get the body of the component which add in the object
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlay)
        {
            transform.position = paddle.position; // the ball position in the paddle
        }

        if (Input.GetButtonDown("Jump") && !isPlay) // press the Spacebar and release the ball
        {
            isPlay = true;
            rb.AddForce(Vector2.up * speed);

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bottom")) // check if the ball hit that object
        {
            Debug.Log("You lose!!");
            rb.velocity = Vector2.zero; // kill all the force if the ball hit the bottom
            isPlay = false; 
        }
    }
=======
    [SerializeField]
    private Transform paddle; //get the paddle position
    [SerializeField]
    private float force = 10f;
    private Rigidbody2D rb;
    private bool isOnPaddle = true;
    public bool HasTouchBottom { get; set; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        MoveToPaddle();
    }
    private void Update()
    {
        if (isOnPaddle)
        {
            transform.position = paddle.position;
        }
    }
    public void LaunchBall()
    {
        isOnPaddle = false;
        rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
    }
    public void MoveToPaddle()
    {
        HasTouchBottom = false;
        isOnPaddle = true;
        rb.velocity = Vector2.zero;
    }
    public void Die()
    {
        gameObject.SetActive(false);
    }
>>>>>>> master
}
