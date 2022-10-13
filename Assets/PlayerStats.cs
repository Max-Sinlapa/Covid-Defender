using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney;

    public static int Base_Hp;
    public int start_Base_Hp;

    public static int Rounds = -1;
    void Start()
    {
        Money = startMoney;
        Base_Hp = start_Base_Hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
