using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    private RectTransform m_healthBar;

    #region Private Variables
    private float p_healthBarOriginalWidth;
    #endregion

    #region Intialization
    private void Awake()
    {
        p_healthBarOriginalWidth = m_healthBar.sizeDelta.x;
    }
    #endregion

    #region Update Health Bar
    public void UpdateHealth(float percent)
    {
        m_healthBar.sizeDelta = new Vector2(p_healthBarOriginalWidth * percent, m_healthBar.sizeDelta.y);
    }

    #endregion
}
