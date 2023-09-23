using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerControls : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 offset;

    private float maxLeft;
    private float maxRight;
    private float maxDown;
    private float maxUp;

    void Start()
    {
        mainCam = Camera.main;

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;

        maxDown = mainCam.ViewportToWorldPoint(new Vector2(0, 0.05f)).y;
        maxUp = mainCam.ViewportToWorldPoint(new Vector2(0, 0.6f)).y;
    }


    void Update()
    {
        // fingers[0] -> first finger
        if (Touch.fingers[0].isActive)
        {
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPos = myTouch.screenPosition;
            touchPos = mainCam.ScreenToWorldPoint(touchPos);

            if (Touch.activeTouches[0].phase == TouchPhase.Began)
            {
                // distance between touch and player
                offset = touchPos - transform.position;
            }

            // moved -> player moves finger on the screen
            if (Touch.activeTouches[0].phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);
            }
            if (Touch.activeTouches[0].phase == TouchPhase.Stationary)
            {
                transform.position = new Vector3(touchPos.x - offset.x, touchPos.y - offset.y, 0);
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeft, maxRight), Mathf.Clamp(transform.position.y, maxDown, maxUp), 0);
        }
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
}
