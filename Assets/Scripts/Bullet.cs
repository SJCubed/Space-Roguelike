using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    private float speed;
    private float distance;
    private Rigidbody2D bulletRB;
    private Collider2D col2D;
    private Vector3 startPos;

    private void Start()
    {
        if (gameObject.layer == 9)
        {
            speed = 20f;
            distance = 30f;
        }
        else
        {
            speed = 15f;
            distance = 20f;
        }
            
        startPos = transform.position;
        bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.AddRelativeForce(Vector2.up * speed, ForceMode2D.Impulse);
        col2D = GetComponent<Collider2D>();


    }

    private void Update()
    {
        if (Vector3.Distance(startPos, transform.position) >= distance)

        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D()
    {

        Destroy(gameObject);
    }


}
