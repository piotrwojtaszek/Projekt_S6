using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_baseStats : S_costStats
{
    public string m_name;
    public float m_maxHealth;
    public Sprite m_icon;
    public GameObject m_model3D;

    public void CreateCost()
    {
        GameController.Instance.SubstractMineralsAmount(m_createCost.m_oxygen, m_createCost.m_energy, m_createCost.m_xandry);
        GameController.Instance.UIUpdate();
    }
}
