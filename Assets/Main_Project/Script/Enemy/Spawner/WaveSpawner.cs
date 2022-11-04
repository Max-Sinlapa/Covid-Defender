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
    public TextMeshProUGUI waveCountdownText;
    public Transform spawnPoint;
    
    public List<Wave_Object> waves;
    
    private int time_Spawn_Enemy;
    private int countdown = 2;
    
    
    [Header("Event")]
    [SerializeField] protected UnityEvent m_Spawn = new();
    
    [Header("Wave DATA")]
    public int waveIndex;
    public int AllEnemyInWave = 0;
    public int EnemyAlradySpawnInWave = 0;
    public int EnemyDieInWave = 0;
    private int timeTick;
    private bool LevelStart;

    /// <Count Enemy In Wave>
    public List<int> EnemyType_Count;

    /// </Count Enemy In Wave>
    public void Start()
    {
        waveIndex = PlayerStats.Rounds;
        var m_Base = GetComponent<MainBase>();
        LevelStart = false;
        timeTick = 1;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2) && !LevelStart)
        {
            waveIndex++;
            StartWave(waveIndex);
            LevelStart = true;
        }
        ////-----------------------------------------------------------------------

        ///Timer
        if(LevelStart)
            timeTick++;
        
        if (timeTick % 600 == 0)
        {
            countdown += 1;
            SpawnWave(waveIndex);
        }
        ///Timer
        
        waveCountdownText.text = Mathf.Floor(waveIndex + 1).ToString();
        //Debug.Log("Enemy DIE In Wave = " + EnemyDieInWave);
        
    }

    public void RestartLevel()
    {
        Debug.Log("RestartLevel ON");
        PlayerStats.Rounds = -1;
        Time.timeScale = 1;
        waveIndex = PlayerStats.Rounds;
        var moneySystem = GetComponent<Money_System>();
        moneySystem.m_CurrentMoney = moneySystem.m_StartMoney;
        var m_Base = GetComponent<MainBase>();
        m_Base.RestartMainBase();
        LevelStart = false;
    }

    void StartWave(int CurrentWave)
    {
        countdown = 0;
        PlayerStats.Rounds++;
        /////Check EnemyGameObject
        for (int a = 0; a < waves[CurrentWave].m_Enemy.Length; a++)
        {
            if (waves[CurrentWave].m_Enemy[a] == null)
            {
                Debug.Log("Need To Fill 'Enemy GameObject' In All Element WAVE");
                return;
            }
            
            if (EnemyType_Count.Count <= a)
                EnemyType_Count.Add(waves[CurrentWave].m_Enemy[a].count);
            else
                EnemyType_Count[a] = waves[CurrentWave].m_Enemy[a].count; //////Collec_EnemyCount_FormObject
                                                                          
            AllEnemyInWave += waves[CurrentWave].m_Enemy[a].count;
        }
        Debug.Log("WAVE IN LEVEL = " + waves.Count);
        Debug.Log("waveIndex = " + waveIndex);
        Debug.Log("CurrentWave = " + CurrentWave);
        Debug.Log("AllEnemyInWave = " + AllEnemyInWave);
        EnemyAlradySpawnInWave = 0;
        EnemyDieInWave = 0;
    }

    void SpawnWave(int CurrentWave)
    {

        if (EnemyAlradySpawnInWave >= AllEnemyInWave && EnemyDieInWave == AllEnemyInWave)
        {
            Debug.Log("Wave Done "+ EnemyAlradySpawnInWave);
            LevelStart = false;
            return;
        }
        else
        {
            for (int s = 0; s < waves[CurrentWave].m_Enemy.Length; s++)
            {
                time_Spawn_Enemy = waves[CurrentWave].m_Enemy[s].SpawnRate;////////////GetEnemySpawnRate
                if (countdown % time_Spawn_Enemy == 0 && EnemyType_Count[s] != 0)
                {
                    SpawnEnemy(CurrentWave,s);
                    EnemyType_Count[s] -= 1;
                }
                    
            }
        }
    }
    
    public void SpawnEnemy(int CurrentWave, int EnemyType)
    {
        GameObject enemy_PreFab = waves[CurrentWave].m_Enemy[EnemyType].enemy;
        var moneySystem = GetComponent<Money_System>();
        var m_Base = GetComponent<MainBase>();
        var enemyObj = Instantiate(enemy_PreFab, spawnPoint.position, spawnPoint.rotation);
        
        ///////////ADD Money When Enemy Die
        var enemy = enemyObj.GetComponent<Enemy>();
        var money = enemy.moneyDrop;
        enemy.GetKillByTower_Event.AddListener(()=> moneySystem.AddMoney(money));
        enemy.GetKillByTower_Event.AddListener(()=> this.EnemyDieInWave++);
        /////////ADD Money When Enemy Die

        /////Event Enemy Travel END
        enemy.TravelEnd_Event.AddListener(()=> m_Base.DecressHealth(enemy.DamageToBase));
        enemy.TravelEnd_Event.AddListener(()=> this.EnemyDieInWave++);
        /////Event Enemy Travel END

        m_Spawn.Invoke();
        EnemyAlradySpawnInWave++;
        Debug.Log( "EnemyType = " + enemy_PreFab + " /// EnemyCount = " + waves[CurrentWave].m_Enemy[EnemyType].count);
        Debug.Log("EnemyAlradySpawnInWave = "+ EnemyAlradySpawnInWave);
    }
    
    
    
}


