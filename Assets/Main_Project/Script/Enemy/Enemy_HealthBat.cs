using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_HealthBat : MonoBehaviour
{
    public Enemy m_EnemyScript;
    public Slider m_Ui_HealthBar;
    
    void Start()
    {
        m_Ui_HealthBar.maxValue = m_EnemyScript.Start_HealthPoint;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);

        m_Ui_HealthBar.value = m_EnemyScript.Current_HealthPoint;
    }
}
