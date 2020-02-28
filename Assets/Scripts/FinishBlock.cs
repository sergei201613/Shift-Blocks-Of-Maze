using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBlock : MonoBehaviour
{
    private bool win = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MainBlock") && !win)
        {
            StartCoroutine(GameMode.instance.PlayerWon());
            win = true;
        }
    }
}
