using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveFollowingPath : MonoBehaviour
{
    [SerializeField] private Transform positionHolder;
    private readonly List<Vector3> step = new List<Vector3>();
    private int index = 0;

    [SerializeField] private float f_MoveDuration;
    private void Start()
    {
        for (int child = 0; child < positionHolder.childCount; child++)
        {
            var pos = positionHolder.GetChild(child);
            step.Add(pos.position);
        }

        Move();
    }

    private void Move()
    {
        index = (index + 1) % step.Count;
        transform.DOMove(step[index], f_MoveDuration).SetEase(Ease.Linear).OnComplete(() =>
        {
            Move();
        });
    }
}
