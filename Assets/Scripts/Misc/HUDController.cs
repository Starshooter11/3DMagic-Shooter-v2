using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using TMPro;
=======
>>>>>>> 1ddbaaec37360c3a12c38faabdf2b8e3ba648c75
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    private RectTransform m_healthBar;

<<<<<<< HEAD
    [SerializeField]
    private TMP_Text m_text;

=======
>>>>>>> 1ddbaaec37360c3a12c38faabdf2b8e3ba648c75
    #region Private Variables
    private float p_healthBarOriginalWidth;
    #endregion

    #region Intialization
    private void Awake()
    {
        p_healthBarOriginalWidth = m_healthBar.sizeDelta.x;
    }
    #endregion

<<<<<<< HEAD
    #region Update Stuff
=======
    #region Update Health Bar
>>>>>>> 1ddbaaec37360c3a12c38faabdf2b8e3ba648c75
    public void UpdateHealth(float percent)
    {
        m_healthBar.sizeDelta = new Vector2(p_healthBarOriginalWidth * percent, m_healthBar.sizeDelta.y);
    }

<<<<<<< HEAD
    public void UpdateKillCounter()
    {
        m_text.text = m_text.text.Replace(m_text.text.Substring(13), PlayerPrefs.GetInt("KC").ToString());
    }

=======
>>>>>>> 1ddbaaec37360c3a12c38faabdf2b8e3ba648c75
    #endregion
}
