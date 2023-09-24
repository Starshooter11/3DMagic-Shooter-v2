using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCountManager : MonoBehaviour
{
    public static KillCountManager singleton;

    #region Private Variables
    private int m_killCount;
    #endregion


    #region
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }
        m_killCount = 0;

    }
    #endregion

    #region Kill Count Methods

    private void UpdateKillCount()
    {
        m_killCount++;
        PlayerPrefs.SetInt("KC", m_killCount);
    }
 
    public void SetKillCount()
    {
        UpdateKillCount();
    }

    public void Reset()
    {
        m_killCount = 0;
        PlayerPrefs.SetInt("KC", m_killCount);
    }
    #endregion
}
