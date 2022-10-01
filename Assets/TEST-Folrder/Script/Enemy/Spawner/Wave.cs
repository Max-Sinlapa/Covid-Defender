using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Util/WaveParameter")]
public class Wave : ScriptableObject
{
    public GameObject[] enemy;
    public int[] count;
    public float[] SpawnRate;
    
}
