#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball == null) return;
        ball.HasTouchBottom = true;
    }
}
