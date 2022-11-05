using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Money_System : MonoBehaviour
{
    public static int m_StartMoney;
    public static int m_CurrentMoney;
    public PlayerStats playerStat;

    [SerializeField] public TextMeshProUGUI moneyCountText;
    void Start()
    {
        m_StartMoney = playerStat.startMoney;
        m_CurrentMoney = m_StartMoney;

    }

    // Update is called once per frame
    void Update()
    {
        moneyCountText.text = "" + Mathf.Floor(m_CurrentMoney);
    }

    public static void AddMoney(int Amount_Earn_Money)
    {
        m_CurrentMoney += Amount_Earn_Money;
        //Debug.Log("money +++++++" + Amount_Earn_Money);
    }

    public static void DecreaseMoney(int Amount_Decrease_Money)
    {
        m_CurrentMoney -= Amount_Decrease_Money;
        //Debug.Log("money -------" + Amount_Decrease_Money);
    }
}
