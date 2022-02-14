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
            bool leftSide = (this.transform.position.x < 0) ? true : false; 
            GameObject.Find("Scoreboard").GetComponent<Scoreboard>().scored(leftSide);
             this.gameObject.transform.parent.gameObject.GetComponent<BallControll>().resetPos(leftSide);
        }
    }
}