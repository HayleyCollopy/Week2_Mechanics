using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    public float minSwipeDistance = 25.0f; //pixels

    Vector2 starttouch;

    Vector2 endtouch;


    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                starttouch = touch.position;
                endtouch = touch.position;
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
            {
                endtouch = touch.position;
                CheckSwipe();
            }
        }
    }

    void CheckSwipe()
    {
        float vdist = Mathf.Abs(endtouch.y - starttouch.y);
        float hdist = Mathf.Abs(endtouch.x - starttouch.x);
        bool isVerticalSwipe = (vdist > hdist);
        bool swipeDistMet = ( (vdist > minSwipeDistance) || (hdist > minSwipeDistance) );
        if (swipeDistMet)
        {
            if(isVerticalSwipe)
            {
                if(endtouch.y > starttouch.y)
                {
                    Debug.Log("Up");
                    animator.Play("Base Layer.Link_Up");
                }
                else
                {
                    Debug.Log("Down");
                    animator.Play("Base Layer.Link_Down");
                }
            }
            else
            {
                if(endtouch.x > starttouch.x)
                {
                    Debug.Log("Right");
                    animator.Play("Base Layer.Link_Right");
                }
                else
                {
                    Debug.Log("Left");
                    animator.Play("Base Layer.Link_Left");
                }
            }
        }
    }
}
