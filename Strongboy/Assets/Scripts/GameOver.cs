using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public SwipeTest swipeTest;
    public  int score;
    public GameObject SceneLoader;
    Speed speed;
    EnemyGenerator enemyGenerator;
    PrefabGenerator prefabGenerator;
    public GameObject GameOverMenu;
    public Text ScoreText;
    public Text BestText;
    public bool isGamePaused;
    public GameObject SmallEnemy;
    public GameObject MediumEnemy;
    public GameObject BigEnemy;
    public int BestScore;
    public GameObject NewHighscoreText;

    void Start()
    {
        isGamePaused = false;
        speed = SceneLoader.GetComponent<Speed>();
        SaveSerial saveSerial = SceneLoader.GetComponent<SaveSerial>();
        enemyGenerator = SceneLoader.GetComponent<EnemyGenerator>();
        prefabGenerator = SceneLoader.GetComponent<PrefabGenerator>();

        SmallEnemy.GetComponent<TouchControl>().enabled = true;
        MediumEnemy.GetComponent<TouchControl>().enabled = true;
        BigEnemy.GetComponent<TouchControl>().enabled = true;

        saveSerial.LoadGame();
        BestScore = saveSerial.intToSave;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Game over"); 
        Debug.Log("Final score: " + score);
        speed.SpeedValue = 0;
        speed.SpeedIncrease = 0;
        enemyGenerator.enabled = false;
        prefabGenerator.enabled = false;
        GameOverMenu.SetActive(true);
        ScoreText.text += score.ToString();
        isGamePaused = true;
     // gameObject.Find("BigEnemy").GetComponent(TouchControl).enabled = false;
     // gameObject.Find("MediumEnemy").GetComponent(TouchControl).enabled = false;
        SmallEnemy.GetComponent<TouchControl>().enabled = false;
        MediumEnemy.GetComponent<TouchControl>().enabled = false;
        BigEnemy.GetComponent<TouchControl>().enabled = false;
        if (score > BestScore)
        {
            BestScore = score;
            SavePrefs savePrefs = SceneLoader.GetComponent<SavePrefs>();
            savePrefs.intToSave = score;
            savePrefs.SaveGame();
            NewHighscoreText.SetActive(true);
        }
        BestText.text += BestScore.ToString();
    }

}


