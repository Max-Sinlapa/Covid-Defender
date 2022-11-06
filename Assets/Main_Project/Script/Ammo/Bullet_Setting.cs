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
        FirstPosition = target.transform.position;
    }
    void Update()
    {
        Destroy(this.gameObject,8);

        if (this.gameObject.CompareTag("Bullet-V1") || this.gameObject.CompareTag("Bullet-V2"))
            BulletTravelNormal();
        if (this.gameObject.CompareTag("Bullet-V3"))
            BulletTravel_3();
        /*
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
        */
    }

    void BulletTravelNormal()
    {
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void BulletTravel_3()
    {
        Vector3 NoTargetDirection = transform.position - FirstPosition;
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(NoTargetDirection.normalized * distanceThisFrame, Space.World);
        
        
        if (this.transform.position.y > 4 || this.transform.position.y < 2)
        {
            if (this.transform.position.y > 4)
            {
                var transformLocalPosition = transform.localPosition;
                transformLocalPosition.y -= 0.01f;
                transform.localPosition = transformLocalPosition;
            }
            if (this.transform.position.y < 2)
            {
                var transformLocalPosition = transform.localPosition;
                transformLocalPosition.y += 0.1f;
                transform.localPosition = transformLocalPosition;
            }
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
            if (this.gameObject.CompareTag("Bullet-V3"))
                DamageToEnemy(other);
                
            
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
