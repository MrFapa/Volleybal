using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    GameObject player;


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            this.player.GetComponent<PlayerController>().setJump(true);
        }
    }
}
