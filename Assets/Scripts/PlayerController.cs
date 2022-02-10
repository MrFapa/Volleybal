using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    float jumpForce;
    GameObject player;
    Rigidbody2D rb;

    float horizontalMov = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.player = this.gameObject;
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this.horizontalMov = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        int lookDirection = (int)horizontalMov;

        if (lookDirection != 0)
        {
            this.player.transform.localScale = new Vector3(lookDirection, 1, 0);
        }

    }

    void FixedUpdate()
    {
        move();

    }

    void move()
    {
        Vector2 newVelocity = new Vector2(horizontalMov * speed * Time.fixedDeltaTime, rb.velocity.y);
        Debug.Log(newVelocity);

        this.rb.velocity = newVelocity;
    }

}