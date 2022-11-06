using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainBase : MonoBehaviour
{
    public int Start_HealthBase;
    public int Current_HealthBase;
    public Slider m_SliderTimer;
    public UnityEvent m_BaseHitEvent = new();
    public UnityEvent m_DestroyBaseEvent = new();
    public PlayerStats playerStat;
    // Start is called before the first frame update
    void Start()
    {
        Start_HealthBase = playerStat.start_Base_Hp;
        Current_HealthBase = Start_HealthBase;
        m_SliderTimer.maxValue = Start_HealthBase;
    }

    // Update is called once per frame
    void Update()
    {
        m_SliderTimer.value = Current_HealthBase;
        
        if(Current_HealthBase <= 0)
            m_DestroyBaseEvent.Invoke();
    }

    public void DecressHealth(int decressAmount)
    { 
        Current_HealthBase -= decressAmount;
        m_BaseHitEvent.Invoke();
    }
    

    public void RestartMainBase()
    {
        Current_HealthBase = Start_HealthBase;
    }
    
}
