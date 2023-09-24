using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager singleton;

    #region Private Variables
    private int m_curScore;
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
        m_curScore = 0;

    }
    #endregion

    #region Score Methods
    public void IncreaseScore(int amount)
    {
        m_curScore += amount;
    }

    private void UpdateHighScore()
    {
        if (!PlayerPrefs.HasKey("HS"))
        {
            PlayerPrefs.SetInt("HS", m_curScore);
            return;
        }

        int hs = PlayerPrefs.GetInt("HS");

        if( hs < m_curScore)
        {
            PlayerPrefs.SetInt("HS", m_curScore);
        }
    }
    #endregion

    #region Destruction
    private void OnDisable()
    {
        UpdateHighScore();
    }
    #endregion


}
