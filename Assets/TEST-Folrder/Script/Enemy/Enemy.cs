using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    //Enemy-Parameter
    public int HealthPoint = 100;
    public float speed = 10f;
    public float Slow_persentage = 0.5f;
    private float DefaultSpeed;
    
    //Enemy-WayPoint
    private Transform targetPoint;
    private int waypointintIndex = 0;
    
    [Header("Event")]
    [SerializeField] protected UnityEvent onDestroyEvent = new();

    void Start()
    {
        targetPoint = WayPoint.points[0];
        DefaultSpeed = speed;
    }

    void Update()
    {
        Vector3 direc = targetPoint.position - transform.position;
        transform.Translate(direc.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targetPoint.position) <= 0.4f)
            GetNextWaypoint();

        
        if (HealthPoint <= 0)
        {
            DestroyEnemy();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointintIndex >= WayPoint.points.Length - 1)
        {
            Destroy(gameObject); ////////////////////////////////////////*** DESTROY OBJECT [EndLine] ****///////////////////////////
            return;
        }
        waypointintIndex++;
        targetPoint = WayPoint.points[waypointintIndex];
    }

    #region Event
    public void EnemyGetSlow()
    {
        speed = speed * Slow_persentage;
    }

    public void EnemyGetDefaulSpeed()
    {
        speed = DefaultSpeed;
    }

    public void DestroyEnemy()
    {
        onDestroyEvent.Invoke();
        Destroy(gameObject);
    }

    public void DamageToEnemy(int Damage)
    {
        HealthPoint -= Damage;
    }

    #endregion
}
