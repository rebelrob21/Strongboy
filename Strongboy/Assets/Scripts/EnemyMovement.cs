using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject target;
    public GameObject SceneLoader;
    public float speed;
    Speed speedd;

    void Start()
    {
        SceneLoader = GameObject.Find("SceneLoader");
        target = GameObject.Find("Strongboy");
        speedd = SceneLoader.GetComponent<Speed>();
    }

   
    void FixedUpdate()
    {
        Vector3 a = transform.position;
        Vector3 b = target.transform.position;
        transform.position = Vector3.MoveTowards(a, b, speedd.SpeedValue);
    }
}
