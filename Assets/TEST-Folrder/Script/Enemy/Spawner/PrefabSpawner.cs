using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Util/PrefabSpawner")]
public class PrefabSpawner : ScriptableObject
{
    public GameObject m_Prefab;

    public void SpawnPrefab(GameObject parent)
    {
        var go = Instantiate(m_Prefab);
        go.transform.position = parent.transform.position;
        
    }
}
