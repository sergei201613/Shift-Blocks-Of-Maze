using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyButton : MonoBehaviour, IPointerClickHandler
{
    public AudioClip clickSound;

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.instance.PlaySound(clickSound);
    }
}
