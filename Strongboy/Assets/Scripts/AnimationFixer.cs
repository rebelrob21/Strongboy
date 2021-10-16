using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFixer : MonoBehaviour
{

    public GameObject Strongboy;

 
    
    void Update()
    {
        Strongboy.transform.rotation = Quaternion.Euler(0, 0, 0);
        Strongboy.transform.position = new Vector3(2.5f, this.transform.position.y, this.transform.position.z);
    }
}
