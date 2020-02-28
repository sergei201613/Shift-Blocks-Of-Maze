using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeDetector : MonoBehaviour, IBeginDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            // Horizontal drag.
            if (eventData.delta.x > 0)
            {
                // Right drag.
                GameMode.instance.MoveAllBoxes(Vector2.right);
            }
            else
            {
                // Left drag.
                GameMode.instance.MoveAllBoxes(Vector2.left);
            }
        }
        else
        {
            // Vertical drag.
            if (eventData.delta.y > 0)
            {
                // Up drag.
                GameMode.instance.MoveAllBoxes(Vector2.up);
            }
            else
            {
                // Down drag.
                GameMode.instance.MoveAllBoxes(Vector2.down);
            }
        }
    }
}
