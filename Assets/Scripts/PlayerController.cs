using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{

    [SerializeField]
    float speed;

    [SerializeField]
    float jumpForce;

    [Space(10)]

    [SerializeField]
    string moveSet;

    [SerializeField]
    KeyCode jumpButton;

    GameObject player;
    Rigidbody2D rb;

    bool canJump = false;

    float horizontalMov = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.player = this.gameObject;
        this.rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (!photonView.IsMine)
        {
            return;
        }
        this.horizontalMov = Input.GetAxisRaw(this.moveSet);

        if (Input.GetKeyDown(this.jumpButton) && this.canJump)
        {
            this.canJump = false;
            this.rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        int lookDirection = (int)horizontalMov;

        if (lookDirection == 0) return;

        this.player.transform.localScale = new Vector3(lookDirection, 1, 0);


    }

    void FixedUpdate()
    {
        move();

    }

    void move()
    {
        Vector2 newVelocity = new Vector2(horizontalMov * this.speed * Time.fixedDeltaTime, rb.velocity.y);
        Debug.Log(newVelocity);

        this.rb.velocity = newVelocity;
    }

    public void setJump(bool value)
    {
        this.canJump = value;
    }

}
