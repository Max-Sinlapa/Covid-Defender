using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    [SerializeField] public TextMeshProUGUI waveCountdownText;
    
    [Header("Event")]
    [SerializeField] protected UnityEvent m_Spawn = new();
    
    //private int waveIndex = 0;
        
    void Update()
    {
        if (countdown <= 0f)
        {
            m_Spawn.Invoke();
            countdown = timeBetweenWaves;
            Debug.Log("SSSS");
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Floor(countdown).ToString();
    }

}
