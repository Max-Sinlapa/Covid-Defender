using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public Transform spawnPoint;

    public Wave[] waves;
    
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public TextMeshProUGUI waveCountdownText;
    
    
    [Header("Event")]
    [SerializeField] protected UnityEvent m_Spawn = new();
    
    private int waveIndex = -1;
    private int AllEnemyInWave = 0;
    private int EnemyAlradySpawnInWave = 0;
    private int EnemySlectedToRespawn;

    /// <Count Enemy In Wave>
    private int EnemyType_1_Count;
    private int EnemyType_2_Count;
    private int EnemyType_3_Count;
    /// </Count Enemy In Wave>
    void Update()
    {
        
        if (countdown <= 0f)
        {
            SpawnWave(waveIndex);
            countdown = timeBetweenWaves;
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            waveIndex++;
            StartWave(waveIndex);
            EnemyAlradySpawnInWave = 0;
            Debug.Log("waveIndex = " + waveIndex);
        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Floor(countdown).ToString();
    }

    void StartWave(int CurrentWave)
    {
        Wave wave = waves[CurrentWave];
        
        /////Check EnemyGameObject
        for (int a = 0; a < wave.enemy.Length; a++)
        {
            if (wave.enemy[a] == null)
            {
                Debug.Log("Need To Fill 'Enemy GameObject' In All Element WAVE");
                return;
            }
        }

        /////Check EnemyCount
        for (int b = 0; b < wave.count.Length; b++)
        {
            if (wave.count[b] == null)
            {
                Debug.Log("Need To Fill 'Count' In All Element WAVE");
                return;
            }
            AllEnemyInWave += wave.count[b];
        }
        
        /////Check EnemySpawnRate
        for (int b = 0; b < wave.SpawnRate.Length; b++)
        {
            if (wave.SpawnRate[b] == null)
            {
                Debug.Log("Need To Fill 'SpawnRate' In All Element WAVE");
                return;
            }
        }
        
        Debug.Log("AllEnemyInWave = " + AllEnemyInWave);
    }

    void SpawnWave(int CurrentWave)
    {

        if (EnemyAlradySpawnInWave == AllEnemyInWave)
        {
            Debug.Log("Done "+ EnemyAlradySpawnInWave);
            return;
        }
        else
        {
            
            do
            {
                int randomEnemy = Random.Range(0,waves[CurrentWave].enemy.Length);
                EnemySlectedToRespawn = randomEnemy;
            } while (waves[CurrentWave].count[EnemySlectedToRespawn] > 0);
            
            
            SpawnEnemy(CurrentWave,EnemySlectedToRespawn);

        }
    }
    
    
    public void SpawnEnemy(int CurrentWave, int EnemyType)
    {
        GameObject enemyPreFab = waves[CurrentWave].enemy[EnemyType];
        Instantiate(enemyPreFab, spawnPoint.position, spawnPoint.rotation);
        m_Spawn.Invoke();
        
        waves[CurrentWave].count[EnemyType] -= 1;
        timeBetweenWaves = waves[CurrentWave].SpawnRate[EnemyType];
        EnemyAlradySpawnInWave++;
        Debug.Log( "EnemyType = " + waves[CurrentWave].enemy[EnemyType]+" /// EnemyCount = " + waves[CurrentWave].count[EnemyType]);
        Debug.Log("EnemyAlradySpawnInWave = "+ EnemyAlradySpawnInWave);
    }
    
}


