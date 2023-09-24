using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityInfo
{
    #region Editor Variables
    [SerializeField]
    private int m_power;
    public int power
    {
        get
        {
            return m_power;
        }
    }

    [SerializeField]
    private int m_range;
    public int range
    {
        get
        {
            return m_range;
        }
    }


    #endregion
}
