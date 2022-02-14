using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    int scoreLeft = 0;
    int scoreRight = 0;
    
    public void scored(bool leftSide) {
        if (leftSide) {
            this.scoreRight += 1;
        }
        else {
            this.scoreLeft += 1;
        }
        this.GetComponent<Text>().text = this.scoreLeft + " : " + this.scoreRight; 

    }
}