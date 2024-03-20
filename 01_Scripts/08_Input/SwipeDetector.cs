using UnityEngine;

/// <summary>
/// Detects swipe gestures on a touchscreen.
/// </summary>
public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDownPos;
    private Vector2 fingerUpPos;

    public bool detectSwipeAfterRelease = false;

    public float SWIPE_THRESHOLD = 20f;

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPos = touch.position;
                fingerDownPos = touch.position;
            }

            // Detects Swipe while finger is still moving on screen
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeAfterRelease)
                {
                    fingerDownPos = touch.position;
                    DetectSwipe();
                }
            }

            // Detects swipe after finger is released from screen
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPos = touch.position;
                DetectSwipe();
            }
        }
    }

    /// <summary>
    /// Detects the direction of the swipe.
    /// </summary>
    void DetectSwipe()
    {
        float verticalMove = VerticalMoveValue();
        float horizontalMove = HorizontalMoveValue();

        if (verticalMove > SWIPE_THRESHOLD && verticalMove > horizontalMove)
        {
            Debug.Log("Vertical Swipe Detected!");
            if (fingerDownPos.y - fingerUpPos.y > 0)
            {
                OnSwipeUp();
            }
            else if (fingerDownPos.y - fingerUpPos.y < 0)
            {
                OnSwipeDown();
            }
            fingerUpPos = fingerDownPos;
        }
        else if (horizontalMove > SWIPE_THRESHOLD && horizontalMove > verticalMove)
        {
            Debug.Log("Horizontal Swipe Detected!");
            if (fingerDownPos.x - fingerUpPos.x > 0)
            {
                OnSwipeRight();
            }
            else if (fingerDownPos.x - fingerUpPos.x < 0)
            {
                OnSwipeLeft();
            }
            fingerUpPos = fingerDownPos;
        }
        else
        {
            Debug.Log("No Swipe Detected!");
        }
    }

    /// <summary>
    /// Calculates the vertical distance of the swipe.
    /// </summary>
    /// <returns>The vertical distance of the swipe.</returns>
    float VerticalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
    }

    /// <summary>
    /// Calculates the horizontal distance of the swipe.
    /// </summary>
    /// <returns>The horizontal distance of the swipe.</returns>
    float HorizontalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
    }

    /// <summary>
    /// Actions to be performed when swiped up.
    /// </summary>
    void OnSwipeUp()
    {
        // Do something when swiped up
    }

    /// <summary>
    /// Actions to be performed when swiped down.
    /// </summary>
    void OnSwipeDown()
    {
        // Do something when swiped down
    }

    /// <summary>
    /// Actions to be performed when swiped right.
    /// </summary>
    private void OnSwipeRight()
    {
        // Do something when swiped right
    }

    /// <summary>
    /// Actions to be performed when swiped left.
    /// </summary>
    private void OnSwipeLeft()
    {
        // Do something when swiped left
    }
}
