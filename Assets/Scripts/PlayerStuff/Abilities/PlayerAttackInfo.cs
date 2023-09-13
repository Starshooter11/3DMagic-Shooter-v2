using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class PlayerAttackInfo
{
    #region Editor Variables
    [SerializeField]
    private string m_name;
    public string attackName
    {
        get { return m_name; }
    }

    [SerializeField]
    private string m_button;
    public string Button
    {
        get { return m_button; }
    }

    [SerializeField]
    private string m_triggerName;
    public string triggerName
    {
        get { return m_triggerName; }
    }

    [SerializeField]
    private GameObject m_abilityGO;
    public GameObject abilityGO
    {
        get { return m_abilityGO; }
    }

    [SerializeField]
    private Vector3 m_offset;
    public Vector3 offset
    {
        get { return m_offset; }
    }

    [SerializeField]
    private float m_windupTime;
    public float windupTime
    {
        get { return m_windupTime; }
    }

    [SerializeField]
    private float m_frozenTime;
    public float frozenTime
    {
        get { return m_frozenTime; }
    }

    [SerializeField]
    private float m_cdTime;

    [SerializeField]
    private int m_healthCost;
    public int healthCost
    {
        get { return m_healthCost; }
    }

    [SerializeField]
    private Color m_color;
    public Color abilityColor
    {
        get { return m_color; }
    }
    #endregion

    #region Public Variables
    public float CD
    {
        get;
        set;
    }
    #endregion

    #region CD Methods
    public void ResetCD()
    {
        CD = m_cdTime;
    }

    public bool isReady()
    {
        return CD <= 0;
    }
    #endregion

}
