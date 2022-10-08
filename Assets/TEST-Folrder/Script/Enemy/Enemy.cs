using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    //Enemy-Parameter
    public int HealthPoint = 100;
    public int Current_HealthPoint;
    public float speed = 10f;
    public float Current_Speed;
    public float Slow_persentage = 0.5f;
    private float DefaultSpeed;
    
    //Enemy-WayPoint
    private Transform targetPoint;
    private int waypointintIndex = 0;
    
    [FormerlySerializedAs("onDestroyEvent")]
    [Header("Event")]
    [SerializeField] protected UnityEvent GetKillByTower_Event = new();

    void Start()
    {
        targetPoint = WayPoint.points[0];
        Current_HealthPoint = HealthPoint;
        Current_Speed = speed;
        DefaultSpeed = speed;
    }

    void Update()
    {
        Vector3 direc = targetPoint.position - transform.position;
        transform.Translate(direc.normalized * Current_Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targetPoint.position) <= 0.4f)
            GetNextWaypoint();

        
        if (Current_HealthPoint <= 0)
        {
            DestroyEnemy();
        }
    }

    void GetNextWaypoint()
    {
        //////////END PATH//////////
        if (waypointintIndex >= WayPoint.points.Length - 1)
        {
            Destroy(this.gameObject); ////////////////////////////////////////*** DESTROY OBJECT [EndLine] ****//////////////////////////
            return;
        }
        //////////END PATH//////////
        
        waypointintIndex++;
        targetPoint = WayPoint.points[waypointintIndex];
    }

    #region Event
    public void EnemyGetSlow()
    {
        Current_Speed = speed * Slow_persentage;
    }

    public void EnemyGetDefaulSpeed()
    {
        Current_Speed = DefaultSpeed;
    }

    public void DestroyEnemy()
    {
        GetKillByTower_Event.Invoke();
        Destroy(this.gameObject);
    }

    public void RecievDamage(int Damage)
    {
        Current_HealthPoint -= Damage;
    }

    #endregion
}
