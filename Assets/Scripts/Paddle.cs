using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float speed;
    Vector3 movement;
    private MoveComponent moveComponent;
    private void Awake()
    {
        moveComponent = GetComponent<MoveComponent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log(" Wall coming ");
            Rigidbody rbdy = collision.gameObject.GetComponent<Rigidbody>();

            //Stop Moving/Translating
            rbdy.velocity = Vector3.zero;

            //Stop rotating
            rbdy.angularVelocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        speed = moveComponent.getSpeed();

        movement = new Vector3(moveHorizontal, 0f, 0f);
        movement = movement * speed * Time.deltaTime;

       
            transform.position += movement;
        
        
    }
}
