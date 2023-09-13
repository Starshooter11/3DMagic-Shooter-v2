using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnInfo
{
    #region Editor Variables
    [SerializeField]
    private string m_name;
    public string enemyName
    {
        get { return m_name; }
    }

    [SerializeField]
    private GameObject m_enemyGO;
    public GameObject enemyGO
    {
        get { return m_enemyGO; }
    }

    [SerializeField]
    private float m_timeToNextSpawn;
    public float timeToNextSpawn
    {
        get { return m_timeToNextSpawn; }
    }

    [SerializeField]
    private int m_numberToSpawn;
    public int numberToSpawn
    {
        get { return m_numberToSpawn; }
    }
    #endregion
}
