using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Object = System.Object;

public class TurretImpulseLaunchar : MonoBehaviour
{
    [Header("Main SetUp")]    
    [SerializeField] protected Transform m_TurretLaunchPosition;
    [SerializeField] public Transform PartToRotate;
    [SerializeField] protected GameObject m_MissilePrefab;
    
    [Header("FirRate SetUp")]
    [SerializeField] protected float m_AmmoSpeed = 20;
    [SerializeField] public float m_CoolDownToLuanch ;
    [SerializeField] protected float m_CurrentCoolDown = 0;
    
    [Header("LineRender SetUp")]
    [SerializeField] protected bool m_IsDrawGizmos = true;
    [SerializeField] protected float m_LineSize = 0.2f;
    [SerializeField] protected Material m_LineMaterial;
    [SerializeField] protected LineRenderer m_LineRenderer;

    private Transform target;
    void Start()
    {
        m_LineRenderer = gameObject.AddComponent<LineRenderer>();
        if (m_LineMaterial != null)
            m_LineRenderer.material = m_LineMaterial;
            
        m_LineRenderer.startWidth = m_LineSize;
        m_LineRenderer.endWidth = 0;
        m_LineRenderer.enabled = false;
        
    }

    private void Update()
    {
        //reduce coolDown
        m_CurrentCoolDown -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            m_LineRenderer.enabled = true;
            
        }

    }
    
    private void OnTriggerStay(Collider other)
    {
       
        if (other.CompareTag("Enemy"))
        {
            target = other.transform;
            //Laser aiming at player
            m_LineRenderer.SetPosition(0,m_TurretLaunchPosition.position);
            m_LineRenderer.SetPosition(1,other.transform.position);
                
            if (m_CurrentCoolDown <= 0 )
            {
                m_CurrentCoolDown = m_CoolDownToLuanch;
                LaunchBall(other.transform.position);
            }

            RatateGun(other);

        }
        
    }

    private void RatateGun(Collider other)
    {
        Vector3 dir = other.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
 
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
            m_LineRenderer.enabled = false;
    }

    private void LaunchBall(Vector3 targetPosition)
    {
        GameObject Bullet_Go = (GameObject)Instantiate(m_MissilePrefab);
        Bullet_Go.transform.position = m_TurretLaunchPosition.position;
        Bullet_Setting bullet = Bullet_Go.GetComponent<Bullet_Setting>();

        if (bullet != null)
            bullet.Seek(target);
        else
        {
            Rigidbody rb = Bullet_Go.GetComponent<Rigidbody>();
            if (rb is null)
                rb = Bullet_Go.AddComponent<Rigidbody>();

            Vector3 launchDirection = (targetPosition - m_TurretLaunchPosition.position).normalized;

            if (rb is not null)
                rb.AddForce(launchDirection * m_AmmoSpeed, ForceMode.Impulse);
        }
        /* [OLD Bullet Travel]
        Rigidbody rb = Bullet_Go.GetComponent<Rigidbody>();
        if (rb is null)
                rb = Bullet_Go.AddComponent<Rigidbody>();

            Vector3 launchDirection = (targetPosition - m_TurretLaunchPosition.position).normalized;

            if (rb is not null)
                rb.AddForce(launchDirection * m_AmmoSpeed, ForceMode.Impulse);
        //*/

}

    private void OnDrawGizmos()
    {
        if(!m_IsDrawGizmos) 
            return;
            
        Gizmos.color = Color.yellow;
            
        if(m_TurretLaunchPosition is not null)
            Gizmos.DrawSphere(m_TurretLaunchPosition.position ,0.25f);

    }
}
