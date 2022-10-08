using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public List<Wave_Object> waves;
    
    private int time_Spawn_Enemy;
    private int countdown = 2;
    public TextMeshProUGUI waveCountdownText;
    
    [Header("Event")]
    [SerializeField] protected UnityEvent m_Spawn = new();
    
    private int waveIndex = -1;
    private int AllEnemyInWave = 0;
    private int EnemyAlradySpawnInWave = 0;
    private int timeTick;

    /// <Count Enemy In Wave>
    public List<int> EnemyType_Count;

    /// </Count Enemy In Wave>
    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            waveIndex++;
            StartWave(waveIndex);
        }
        ////-----------------------------------------------------------------------


        ///Timer
        timeTick++;
        if (timeTick % 550 == 0)
        {
            countdown += 1;
            SpawnWave(waveIndex);
        }
        waveCountdownText.text = Mathf.Floor(countdown).ToString();
    }

    void StartWave(int CurrentWave)
    {
        countdown = 0;
        /////Check EnemyGameObject
        for (int a = 0; a < waves[CurrentWave].m_Enemy.Length; a++)
        {
            if (waves[CurrentWave].m_Enemy[a] == null)
            {
                Debug.Log("Need To Fill 'Enemy GameObject' In All Element WAVE");
                return;
            }
            //Debug.Log("EnemyType_Count = " + EnemyType_Count[a]);
            //EnemyType_Count[a] = waves[CurrentWave].m_Enemy[a].count; //////Collec_EnemyCount_FormObject
            AllEnemyInWave += waves[CurrentWave].m_Enemy[a].count;
            
            
        }
        Debug.Log("waveIndex = " + waveIndex);
        Debug.Log("CurrentWave" + CurrentWave);
        Debug.Log("AllEnemyInWave = " + AllEnemyInWave);
        EnemyAlradySpawnInWave = 0;
    }

    void SpawnWave(int CurrentWave)
    {

        if (EnemyAlradySpawnInWave >= AllEnemyInWave)
        {
            Debug.Log("Wave Done "+ EnemyAlradySpawnInWave);
            return;
        }
        else
        {
            for (int s = 0; s < waves[CurrentWave].m_Enemy.Length; s++)
            {
                time_Spawn_Enemy = waves[CurrentWave].m_Enemy[s].SpawnRate;////////////GetEnemySpawnRate
                if (countdown % time_Spawn_Enemy == 0)
                {
                    SpawnEnemy(CurrentWave,s);
                    //EnemyType_Count[s] -= 1;
                }
                    
            }
        }
    }
    
    
    public void SpawnEnemy(int CurrentWave, int EnemyType)
    {
        GameObject enemy_PreFab = waves[CurrentWave].m_Enemy[EnemyType].enemy;
        
        Instantiate(enemy_PreFab, spawnPoint.position, spawnPoint.rotation);
        m_Spawn.Invoke();
        
        EnemyAlradySpawnInWave++;
        Debug.Log( "EnemyType = " + enemy_PreFab + " /// EnemyCount = " + waves[CurrentWave].m_Enemy[EnemyType].count);
        Debug.Log("EnemyAlradySpawnInWave = "+ EnemyAlradySpawnInWave);
    }
    
}


