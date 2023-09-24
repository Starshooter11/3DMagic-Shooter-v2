using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private Vector3 m_bounds;

    [SerializeField]
    private EnemySpawnInfo[] m_enemies;
    #endregion


    #region Intialization
    private void Awake()
    {
        StartSpawning();
    }
    #endregion


    #region Spawn Methods
    public void StartSpawning()
    {
        for ( int i = 0; i  < m_enemies.Length; i++)
        {
            StartCoroutine(Spawn(i));
        }
    }

    private IEnumerator Spawn(int enemyInd)
    {
        EnemySpawnInfo info = m_enemies[enemyInd];
        int i = 0;
        bool alwaysSpawn = false;
        if ( info.numberToSpawn == 0)
        {
            alwaysSpawn = true;
        }
        
        while (alwaysSpawn || i < info.numberToSpawn)
        {
            yield return new WaitForSeconds(info.timeToNextSpawn);
            float xVal = m_bounds.x / 2;
            float yVal = m_bounds.y / 2;
            float zVal = m_bounds.z / 2;

            Vector3 spawnPos = new Vector3 (Random.Range(-xVal, xVal), yVal, Random.Range(-zVal, zVal));

            spawnPos += transform.position;
            Instantiate(info.enemyGO, spawnPos, Quaternion.identity);

            if ( !alwaysSpawn)
            {
                i++;
            }

        }

    }
    #endregion
}
