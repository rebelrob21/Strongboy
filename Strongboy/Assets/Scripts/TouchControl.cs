using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    bool tap, swipeUp, swipeDown;
    Vector2 startTouch, swipeDelta;
    private bool isDraging = false;
    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta;  } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public GameObject EnemyCollider;
    public GameOver gameOver;

    void Start()
    {

        EnemyCollider = GameObject.Find("EnemyCollider");
        gameOver = EnemyCollider.GetComponent<GameOver>();
    }

    void Update()
    {
        tap = swipeUp = swipeDown = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }

        #endregion

        #region Mobile Inputs
        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        swipeDelta = Vector2.zero;
        if(isDraging)
        {
            if(Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if(swipeDelta.magnitude > 40)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x) <= Mathf.Abs(y))
            {
                if (y < 0)
                {
                    swipeDown = true;
                    
                }
                else
                {
                    swipeUp = true;
                }
            }

            Reset();
        }

    }

    void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

    void OnMouseDown()
    {
        
        if (gameObject.name == "SmallEnemyClone")
        {
            Destroy(gameObject);
            gameOver.score++;
            //Here should be Zsotika's animation
        }

    }
}
