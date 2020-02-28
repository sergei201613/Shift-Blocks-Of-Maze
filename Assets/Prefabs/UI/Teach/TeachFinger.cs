using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TeachFinger : MonoBehaviour
{
    [SerializeField]
    private Vector2 startDirection = Vector2.down;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        SetDirection(startDirection);
    }

    public void SetDirection(Vector2 dir)
    {
        if (dir == Vector2.down)
            animator.Play("FingerDown");
        else if (dir == Vector2.up)
            animator.Play("FingerUp");
        else if (dir == Vector2.left)
            animator.Play("FingerLeft");
        else if (dir == Vector2.right)
            animator.Play("FingerRight");
    }
}
