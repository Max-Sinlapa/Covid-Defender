using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform targetPoint;
    private int waypointintIndex = 0;

    void Start()
    {
        targetPoint = WayPoint.points[0];
    }

    void Update()
    {
        Vector3 direc = targetPoint.position - transform.position;
        transform.Translate(direc.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targetPoint.position) <= 0.4f)
            GetNextWaypoint();
    }

    void GetNextWaypoint()
    {
        if (waypointintIndex >= WayPoint.points.Length - 1)
        {
            Destroy(gameObject); ////////////////////////////////////////*** DESTROY OBJECT ****///////////////////////////
            return;
        }
        waypointintIndex++;
        targetPoint = WayPoint.points[waypointintIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Bullet-V1"))
        {
            Destroy(gameObject);
        }

    }
}
