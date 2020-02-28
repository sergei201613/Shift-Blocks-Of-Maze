using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Star : MonoBehaviour
{
    public ParticleSystem particle;
    public GameObject graphics;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainBlock"))
        {
            particle.Play();
            audioSource.Play();

            GameMode.instance.starIsTaked = true;

            Destroy(graphics);
            Destroy(gameObject, 3f);
        }
    }
}
