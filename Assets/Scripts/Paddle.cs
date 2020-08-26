using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private MoveComponent moveComponent;
    private void Awake()
    {
        moveComponent = GetComponent<MoveComponent>();
    }
    void Update()
    {
        moveComponent.Move(new Vector2(Input.GetAxisRaw("Horizontal"), 0));
    }
}
