using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private Vector3 fp; //first touch pos
    private Vector3 lp; //last touch pos
    private float dragDistance; //min distance for a swipe

    void Start()
    {
        dragDistance = Screen.height * 15 / 100;
    }


    void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase==TouchPhase.Moved)
            {
                lp = touch.position;
            }
            else if(touch.phase==TouchPhase.Ended)
            {
                lp = touch.position;
                if(Mathf.Abs(lp.x-fp.x)>dragDistance || Mathf.Abs(lp.y-fp.y)>dragDistance)
                {
                    
                    {
                        if ((lp.y > fp.y))
                        {
                            Debug.Log("Up");
                        }
                        else
                        {
                            Debug.Log("Down");
                        }
                    }
                }
            }
        }
    }
}
