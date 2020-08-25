using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float speed;
    Vector2 movement;
    private MoveComponent moveComponent;
    public Rigidbody2D rb;

    private bool flag_controlled_force = false;

    private void Awake()
    {
        moveComponent = GetComponent<MoveComponent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movePadde(movement);
    }
    void movePadde(Vector2 direction)
    {
        if (this.flag_controlled_force == true)
        {
            rb.AddForce(direction * this.speed, ForceMode2D.Force);
        } else
        {
            rb.velocity = direction * this.speed;
        }
   
        
    }
    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        speed = moveComponent.getSpeed();
        movement = new Vector2(moveHorizontal, moveVertical);
    }
}
