using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private TMP_Text m_highscore;
    #endregion

    #region Private Vaiables
    private string m_defaultHighScore;
    #endregion

    #region Intialization
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        m_defaultHighScore = m_highscore.text;
        
    }

    private void Start()
    {
        UpdateHighscore();
    }
    #endregion

    #region Play Button Methods
    public void PlayArena()
    {
        SceneManager.LoadScene("Arena");
    }

    #endregion

    #region General Application Button Methods
    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Highscore Methods
    private void UpdateHighscore()
    {
        if (PlayerPrefs.HasKey("HS"))
        {
            m_highscore.text = m_defaultHighScore.Replace("%S", PlayerPrefs.GetInt("HS").ToString());
        }
        else
        {
            PlayerPrefs.SetInt("HS", 0);
            m_highscore.text = m_defaultHighScore.Replace("%S", "0");

        }
    }

    public void ResettingScore()
    {
        PlayerPrefs.SetInt("HS", 0);
        UpdateHighscore();
    }
    #endregion
}
