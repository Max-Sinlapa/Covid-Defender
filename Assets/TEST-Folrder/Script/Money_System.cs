using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money_System : MonoBehaviour
{
    public int m_StartMoney;
    
    [SerializeField] public TextMeshProUGUI moneyCountText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyCountText.text = Mathf.Floor(m_StartMoney).ToString();
    }

    public void AddMoney(int Amount_Earn_Money)
    {
        m_StartMoney += Amount_Earn_Money;
    }

    public void DecreaseMoney(int Amount_Decrease_Money)
    {
        m_StartMoney -= Amount_Decrease_Money;
    }
}
