using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float _scrollSreed;
    [SerializeField] private float _titleSixeY;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * _scrollSreed, _titleSixeY);
        transform.position = _startPosition + Vector3.forward * newPosition;
    }
}
