using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazaGlownaController : BuildingController
{
    public int m_amount = 1;

    public override void Awake()
    {
        base.Awake();

    }

    void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Collect()
    {
        GameController.Instance.AddMineralsAmount(m_amount, m_amount, m_amount);
    }

    public override void Interaction()
    {
        Debug.Log("Nastąpiła interakcja z :" + m_settings.m_name);
    }

    public override void SetPlaced(bool value)
    {
        base.SetPlaced(value);
        UIController.Instance.m_buildingUI.ChangeCards();
    }
    public override void Upgrade()
    {
        if (GameController.Instance.CheckIfEnoughMinerals
(m_settings.m_upgradeCost.m_oxygen, m_settings.m_upgradeCost.m_energy, m_settings.m_upgradeCost.m_xandry))
        {
            GameController.Instance.SubstractMineralsAmount(m_settings.m_upgradeCost.m_oxygen, m_settings.m_upgradeCost.m_energy, m_settings.m_upgradeCost.m_xandry);
            m_level++;
            GameController.Instance.SetMaxBuildingsNumber(5);
        }

    }
}