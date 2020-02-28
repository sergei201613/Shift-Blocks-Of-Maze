using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SwipeTeacher : MonoBehaviour, IBeginDragHandler
{
    public TeachFinger finger;
    public Vector2[] stepDirections;

    [SerializeField] private byte step = 0;
    private Vector2 dir = Vector2.zero;

    private void Awake()
    {
        // Player must teach swies on 1-st level,
        // for this we have other component.

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            enabled = true;
            GetComponent<SwipeDetector>().enabled = false;
        }
        else
        {
            enabled = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Calculate drag direction.

        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            // Horizontal drag.
            if (eventData.delta.x > 0)
            {
                // Right drag.
                dir = Vector2.right;
            }
            else
            {
                // Left drag.
                dir = Vector2.left;
            }
        }
        else
        {
            // Vertical drag.
            if (eventData.delta.y > 0)
            {
                // Up drag.
                dir = Vector2.up;
            }
            else
            {
                // Down drag.
                dir = Vector2.down;
            }
        }

        if (dir == stepDirections[step])
        {
            if (GameMode.instance.MoveAllBoxes(dir))
            {
                if (step < 3)
                    step++;

                finger.SetDirection(stepDirections[step]);
            }
        }
    }
}
