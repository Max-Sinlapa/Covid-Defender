using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI roundText;

    void OnEnable()
    {
        roundText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene("01");
        Debug.Log("Game Restart");
    }

    public void Menu()
    {
        SceneManager.LoadScene("");
        Debug.Log("To Menu");
    }

    public void NextLevel(String next_Level)
    {
        SceneManager.LoadScene(next_Level);
        Debug.Log("Next Level");
    }
}