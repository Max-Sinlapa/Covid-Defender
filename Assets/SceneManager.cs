using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class SceneManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI roundText;
    public static int RoundOffSet = 0;
    private int Current_Round;

    void Update()
    {
        Current_Round = PlayerStats.Rounds + RoundOffSet;
        Debug.Log("Current_Round = " + Current_Round);
        roundText.text = Current_Round.ToString();
    }

    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("01");
        Debug.Log("Game Restart");
    }

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("");
        Debug.Log("To Menu");
    }

    public void NextLevel(String next_Level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(next_Level);
        Debug.Log("Next Level");
    }
}