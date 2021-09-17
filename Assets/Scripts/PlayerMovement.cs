using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    AnimationController animationController;
    public float forwardSpeed;
    private float xMin = -4.5f, xMax = 4.5f;
    private float xPos;
    Touch touch;
    Vector3 firstTouchPos;
    float deltaSwipeX, lastXPosition;

    //[SerializeField]
    //Animator playerAnimator;

    [SerializeField]
    private int sideSpeed;
    private void Awake()
    {
        animationController = FindObjectOfType<AnimationController>();
        xPos = transform.position.x;
    }
    void Update()
    {
        SwipeControl();

        MovingForward();
        SideMovingControls();


    }
    void SwipeControl()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstTouchPos = touch.position;
            }
            deltaSwipeX = touch.position.x - firstTouchPos.x;
            if (touch.phase == TouchPhase.Ended)
            {
                lastXPosition = transform.position.x;
                deltaSwipeX = 0;
            }
        }
    }


    void MovingForward()
    {
        
            transform.position += Vector3.forward * forwardSpeed * Time.deltaTime; // forwardSpeed (1+"speed") kadar katlanýyor.
        
    }

    void SideMovingControls()
    {
       
            // Klavye Kontrol
            xPos = Mathf.Clamp(transform.position.x, xMin, xMax);
            xPos += Input.GetAxis("Horizontal") * sideSpeed * Time.deltaTime;

            transform.position = new Vector3(Mathf.Clamp((deltaSwipeX / 200 + lastXPosition), xMin, xMax), transform.position.y, transform.position.z);

        
    }
    



}
