using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class ObstacleController : MonoBehaviour
{
    [Header("Movement Variable")] 
    [SerializeField] private bool canMove;
    [SerializeField] private float speed;
    [SerializeField] private Transform[] points;
    
    [Header("Rotate Variable")]
    [SerializeField] private bool canRotate = true;
    [SerializeField] private float rotateSpeed;
    
    private Rigidbody _rigidbody;
    
    private Vector3[] wayPoints;
    
    private int activeIndex = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (points.Length == 0)
        {
            wayPoints = new Vector3[transform.childCount + 1];
        
            wayPoints[0] = transform.position;
        
            for (int i = 0; i < transform.childCount; i++)
            {
                wayPoints[i + 1] = transform.GetChild(i).position;
            }
        }
        else
        {
            wayPoints = new Vector3[points.Length];
        
            for (int i = 0; i < points.Length; i++)
            {
                wayPoints[i] = points[i].position;
            } 
        }
    }

    private void Start()
    {
        Move();

        if (canRotate)
        {
            _rigidbody.angularDrag = 0;
            _rigidbody.angularVelocity = Vector3.up * rotateSpeed;
        }
    }

    private void Update()
    {
        if (!canMove) return;

        if (Vector3.Distance(transform.position, wayPoints[activeIndex]) < 0.5f)
        {
            activeIndex = activeIndex < wayPoints.Length - 1 ? activeIndex + 1 : 0;
            Move();
        }
    }

    private void Move()
    {
        Vector3 direction = (wayPoints[activeIndex] - transform.position).normalized;

        _rigidbody.velocity = direction * speed;
    }
}
