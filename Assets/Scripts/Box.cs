using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public LayerMask BlockingLayer;
    public float speed;
    public bool isMove = false;

    private Vector3 targetPos;
    private Vector3 lastPos;
    private Vector2 dir = Vector2.zero;

    private RaycastHit2D hit;
    private Transform transformComp;

    void Awake()
    {
        transformComp = GetComponent<Transform>();

        targetPos = transform.position;
        lastPos = transform.position;
    }

    void Update()
    {
        MoveToTargetUpdate();
    }

    private void MoveToTargetUpdate()
    {
        CalculateTargetPos();

        transformComp.position = Vector3.
            MoveTowards(transformComp.position, targetPos, speed * Time.deltaTime);

        if (lastPos == transformComp.position)
        {
            isMove = false;
        }
        else
        {
            isMove = true;
        }

        lastPos = transformComp.position;
    }

    public void MoveBox(Vector2 newDir)
    {
        dir = newDir;
        isMove = true;
    }

    private void CalculateTargetPos()
    {
        gameObject.layer = 0;
        hit = Physics2D.Raycast(transformComp.position, dir, 30f, BlockingLayer);
        gameObject.layer = 9;

        if (dir != Vector2.zero)
            targetPos = hit.point - (dir * 0.5f);
        else
            targetPos = transformComp.position;
    }
}