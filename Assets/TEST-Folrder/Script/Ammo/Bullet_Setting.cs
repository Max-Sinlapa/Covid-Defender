using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet_Setting : MonoBehaviour
{
    [SerializeField] public bool Destroy_When_Hit;
    public float speed = 70f;
    
    private Transform target;
    private Vector3 FirstPosition;

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

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Bullet HIT Enemy");
            if(Destroy_When_Hit == true)
                Destroy(this.gameObject);
        }
    }

   
}
