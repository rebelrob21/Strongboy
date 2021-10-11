using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public SwipeTest swipeTest;
    public int score;
    GameObject SceneLoader;
    Speed speed;
    EnemyGenerator enemyGenerator;
    PrefabGenerator prefabGenerator;

    void Start()
    {
        
        SceneLoader = GameObject.Find("SceneLoader");
        speed = SceneLoader.GetComponent<Speed>();
        enemyGenerator = SceneLoader.GetComponent<EnemyGenerator>();
        prefabGenerator = SceneLoader.GetComponent<PrefabGenerator>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Game over"); // Here should be shown Elod's game over menu
        Debug.Log("Final score: " + score);
        speed.SpeedValue = 0;
        speed.SpeedIncrease = 0;
        enemyGenerator.enabled = false;
        prefabGenerator.enabled = false;
    }

}
