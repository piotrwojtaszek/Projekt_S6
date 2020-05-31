﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElektrowniaController : BuildingController
{
    public float m_rate = 5f;
    public int m_amount = 2;
    private float m_currTime = 0f;
    // Start is called before the first frame update

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
        if (GetPlaced())
            CreateEnergy();
    }

    void CreateEnergy()
    {
        m_currTime += Time.deltaTime;
        if (m_currTime >= m_rate)
        {
            if(GameController.Instance.CheckIfEnoughMinerals(m_settings.m_livingCost.m_oxygen, m_settings.m_livingCost.m_energy, m_settings.m_livingCost.m_xandry + m_amount))
            {
                GameController.Instance.AddMineralsAmount(0f, m_amount+(3*m_level), 0f);
                
            }
            GameController.Instance.SubstractMineralsAmount(m_settings.m_livingCost.m_oxygen, m_settings.m_livingCost.m_energy, m_settings.m_livingCost.m_xandry + m_amount);
            m_currTime = 0f;
        }
    }

    public override void Interaction()
    {
        Debug.Log("Nastąpiła interakcja z :" + m_settings.m_name);
    }
}
