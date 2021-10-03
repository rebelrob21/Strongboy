using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public SwipeTest swipeTest;
    public int score;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Game over"); // Here should be shown Elod's game over menu
        Debug.Log("Final score: " + score);

    }

}
