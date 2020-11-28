using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlatform : MonoBehaviour
{
    public float jumpSpeed;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rigidBody = collision.collider.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                FindObjectOfType<AudioManager>().Play("GhostPlatform");

                Vector2 vel = rigidBody.velocity;
                vel.y = jumpSpeed;
                rigidBody.velocity = vel;

                Destroy(this.gameObject);
            }
        }

    }
}
