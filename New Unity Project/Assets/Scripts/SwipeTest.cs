using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour
{
    public GameOver gameOver;
    public TouchControl touchControls;



    private void Update()
    {
        if (touchControls.SwipeUp)
        {
            Debug.Log("Swiped up");
            if(gameObject.name == "BigEnemyClone")
            {
                gameOver.score++;
                Destroy(gameObject);
                //Here should be Zsotika's animation
             
            }
            
            
        }
        if (touchControls.SwipeDown)
        {
            Debug.Log("Swiped down");
            if (gameObject.name == "MediumEnemyClone")
            {
                gameOver.score++;
                Destroy(gameObject);
                //Here should be Zsotika's animation
            }
        }
    
    }

    
   
}
