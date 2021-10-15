using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
   
    public GameObject BigEnemy;
    public GameObject MediumEnemy;
    public GameObject SmallEnemy;
    public GameObject EnemySpawnPoint;
    float timer = 0.1f;
    int RandomNumber;
    public float timeUntilNextEnemyIsSpawned = 3;
    float timeDecrease = 0.0001f;

    void Start()
    {
        
    }

    void Update()
    {
        timeUntilNextEnemyIsSpawned -= timeDecrease;
            EnemyGeneratorFunction();
        
      
    }

   

    void EnemyGeneratorFunction()
    {

        RandomNumber = Random.Range(0, 3);

        if (RandomNumber == 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = timeUntilNextEnemyIsSpawned;
                StartCoroutine(BigEnemyGenerator());
            }

         

        }
        if (RandomNumber == 1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = timeUntilNextEnemyIsSpawned;
                StartCoroutine(MediumEnemyGenerator());
            }
          

        }
        if (RandomNumber == 2)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = timeUntilNextEnemyIsSpawned;
                StartCoroutine(SmallEnemyGenerator());
            }
          

        }


    }

    IEnumerator BigEnemyGenerator()
    {
       
        yield return new WaitForSeconds(2);
        GameObject BigEnemyClone = GameObject.Instantiate(BigEnemy);
        BigEnemyClone.transform.position = EnemySpawnPoint.transform.position;
        BigEnemyClone.name = "BigEnemyClone";
    }

    IEnumerator MediumEnemyGenerator()
    {
        
        yield return new WaitForSeconds(2);
        GameObject MediumEnemyClone = GameObject.Instantiate(MediumEnemy);
        MediumEnemyClone.transform.position = EnemySpawnPoint.transform.position;
        MediumEnemyClone.name = "MediumEnemyClone";
    }

    IEnumerator SmallEnemyGenerator()
    {
       
        yield return new WaitForSeconds(2);
        GameObject SmallEnemyClone = GameObject.Instantiate(SmallEnemy);
        SmallEnemyClone.transform.position = EnemySpawnPoint.transform.position;
        SmallEnemyClone.name = "SmallEnemyClone";
    }

}
