using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    private RectTransform m_healthBar;

    [SerializeField]
    private TMP_Text m_text;

    #region Private Variables
    private float p_healthBarOriginalWidth;
    #endregion

    #region Intialization
    private void Awake()
    {
        p_healthBarOriginalWidth = m_healthBar.sizeDelta.x;
    }
    #endregion

    #region Update Stuff
    public void UpdateHealth(float percent)
    {
        m_healthBar.sizeDelta = new Vector2(p_healthBarOriginalWidth * percent, m_healthBar.sizeDelta.y);
    }

    public void UpdateKillCounter()
    {
        m_text.text = m_text.text.Replace(m_text.text.Substring(13), PlayerPrefs.GetInt("KC").ToString());
    }

    #endregion
}
