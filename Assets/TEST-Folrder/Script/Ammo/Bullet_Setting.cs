using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Bullet_Setting : MonoBehaviour
{
    public float speed = 70f;
    [SerializeField] public bool Destroy_When_Hit;
    public int Damage;
    
    private Transform target;
    private Vector3 FirstPosition;
    
    //[Header("Event")]
    //[SerializeField] protected UnityEvent m_Bullet_WhenHitEnemy = new();

    void Start()
    {
        FirstPosition = this.transform.position;
    }
    void Update()
    {
        Destroy(this.gameObject,2);
        if(target == null) ////<<<<<<<<<<Travel-With-NO-Target
        {
            Vector3 NoTargetDirection = transform.position - FirstPosition;
            float distanceThisFrame = speed * Time.deltaTime;
            transform.Translate(NoTargetDirection.normalized * distanceThisFrame, Space.World);
        }
        else       ////<<<<<<<<<<Travel-With-Target
        {
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;
            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        }
    }
    
    public void Seek(Transform _target)
    {
        target = _target;
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            if (this.gameObject.CompareTag("Bullet-V1"))
                DamageToEnemy(other);
            if (this.gameObject.CompareTag("Bullet-V2"))
            {
                DamageToEnemy(other);
                SlowEnemy(other);
            }
                
            
            if(Destroy_When_Hit == true)
                Destroy(this.gameObject);
        }
    }

    public void DamageToEnemy(Collider other)
    {
        var Enemy = other.GetComponent<Enemy>();
        Enemy.RecievDamage(Damage);
    }

    public void SlowEnemy(Collider other)
    {
        var Enemy = other.GetComponent<Timer_V2>();
        Enemy.StartTimer();
    }

}
