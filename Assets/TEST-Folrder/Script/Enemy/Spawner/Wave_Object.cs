using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Util/WaveParameter")]
public class Wave_Object : ScriptableObject
{
    public EnemyType[] m_Enemy;
    
    
}



[Serializable]
public class EnemyType
{
    public GameObject enemy;
    public int count;
    public int SpawnRate;
}
