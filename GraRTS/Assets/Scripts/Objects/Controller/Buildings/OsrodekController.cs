using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsrodekController : BuildingController
{
    public int m_amount = 2;

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

        if (GameController.Instance.CheckIfEnoughMinerals(m_settings.m_livingCost.m_oxygen, m_settings.m_livingCost.m_energy, m_settings.m_livingCost.m_xandry + m_amount))
        {
            GameController.Instance.AddMineralsAmount(m_amount + (3 * m_level), 0f, 0f);

        }
        GameController.Instance.SubstractMineralsAmount(m_settings.m_livingCost.m_oxygen, m_settings.m_livingCost.m_energy, m_settings.m_livingCost.m_xandry + m_amount);

    }


    public override void Interaction()
    {
        Debug.Log("Nastąpiła interakcja z :" + m_settings.m_name);
    }
}
