using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [Header("EnemyParameter")]
    //Enemy-Parameter
    [FormerlySerializedAs("HealthPoint")] public int Start_HealthPoint;
    public int Current_HealthPoint;
    public float speed;
    private float Current_Speed;
    public float Slow_persentage;
    private float DefaultSpeed;

    public int moneyDrop;
    public int DamageToBase;
    
    //Enemy-WayPoint
    private Transform targetPoint;
    private int waypointintIndex = 0;

    [FormerlySerializedAs("onDestroyEvent")]
    [Header("Event")]
    [SerializeField] public UnityEvent GetKillByTower_Event = new();
    [SerializeField] public UnityEvent TravelEnd_Event = new();

    void Start()
    {
        targetPoint = WayPoint.points[0];
        Current_HealthPoint = Start_HealthPoint;
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
            TravelEnd_Event.Invoke();
            Destroy(this.gameObject);
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
    
    
    /*
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainBase"))
        {
            var m_MainBase = other.GetComponent<MainBase>();
            m_MainBase.DecressHealth(DamageToBase);
            Debug.Log("Hit-Base");
        }
    }
    */

    #endregion
}
