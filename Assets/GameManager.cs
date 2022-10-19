using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;
    public static bool Game_Win = false;
    public MainBase Base_Hp;
    public WaveSpawner Spawner_Manager;
    public GameObject Game_Over_UI;
    public GameObject Game_Win_UI;
    
    
    void Start()
    {
        GameIsOver = false;
        Game_Win = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameIsOver)
            return;
        
        if(Base_Hp.Current_HealthBase <= 0 )
            EndGame();
        
        if (Spawner_Manager.EnemyAlradySpawnInWave >= Spawner_Manager.AllEnemyInWave && 
            Spawner_Manager.EnemyDieInWave == Spawner_Manager.AllEnemyInWave && 
            Spawner_Manager.waveIndex + 1 == Spawner_Manager.waves.Count &&
            !GameIsOver)
            WinGame();
    }

    void EndGame()
    {
        GameIsOver = true;
        Game_Over_UI.SetActive(true);
        Spawner_Manager.RestartLevel();
        SceneManager.RoundOffSet = 1;
    }
    
    public void WinGame()
    {
        Debug.Log("WIN GAME");
        Game_Win = true;
        Game_Win_UI.SetActive(true);
        SceneManager.RoundOffSet = 1;
    }
}
