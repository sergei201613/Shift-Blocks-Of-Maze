using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGrid : MonoBehaviour
{
    public GameObject[] starObjects;
    public float delay = 1f;

    private void OnEnable()
    {
        StartCoroutine(StarAppear());

        IEnumerator StarAppear()
        {
            for (int i = 0; i < GameMode.instance.stars; i++)
            {
                starObjects[i].SetActive(true);
                yield return new WaitForSeconds(delay);
            } 
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < starObjects.Length; i++)
        {
            starObjects[i].SetActive(false);
        }
    }
}
