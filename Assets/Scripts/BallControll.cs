using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour
{
    Rigidbody2D rb;
    public float gravityScale = 1;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        rb.gravityScale = 1.0f;

    }

    public void resetPos(bool leftSide)
    {
        this.transform.position = (leftSide) ? new Vector2(5, 0.5f) : new Vector2(-5, 0.5f);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        rb.gravityScale = 0.0f;
    }
}