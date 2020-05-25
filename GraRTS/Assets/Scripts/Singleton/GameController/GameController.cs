using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public Minerals m_minerals;
    [HideInInspector]
    public UIController m_uiController;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        m_minerals.m_energy = 0f;
        m_minerals.m_oxygen = 0f;
        m_minerals.m_xandry = 0f;
        m_uiController = GetComponent<UIController>();
        m_uiController.m_mineralsUI.UpdateMineralsUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            AddMineralsAmount(1.1f, 2.1f, 2.1f);
        if (Input.GetKeyDown(KeyCode.K))
            SubstractMineralsAmount(2f, 1.5f, 3f);
        
    }

    public void AddMineralsAmount(float oxygen, float energy, float xandry)
    {
        m_minerals.m_oxygen += oxygen;
        m_minerals.m_energy += energy;
        m_minerals.m_xandry += xandry;
        m_uiController.m_mineralsUI.UpdateMineralsUI();
    }

    public void SubstractMineralsAmount(float oxygen, float energy, float xandry)
    {
        m_minerals.m_oxygen -= oxygen;
        m_minerals.m_energy -= energy;
        m_minerals.m_xandry -= xandry;
        m_uiController.m_mineralsUI.UpdateMineralsUI();
    }


}
