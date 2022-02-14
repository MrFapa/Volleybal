using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGroundCheck : MonoBehaviour
{
    [SerializeField]
    GameObject ball;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (this.transform.position.x < 0) {
                ball.transform.position = new Vector2(5,7);
            }
            else {
                ball.transform.position = new Vector2(-5,7);
            }
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
    }
}
