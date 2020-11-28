using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour
{
    public float jumpSpeed = 10f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rigidBody = collision.collider.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                FindObjectOfType<AudioManager>().Play("Jump");

                Vector2 vel = rigidBody.velocity;
                vel.y = jumpSpeed;
                rigidBody.velocity = vel;
            }
        }

    }
}
