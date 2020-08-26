#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
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
}
