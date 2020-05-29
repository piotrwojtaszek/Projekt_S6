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
    public bool m_mouseOverUI=false;

    private float m_uiRefreshTime = 0f;
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

        m_minerals.m_energy = 100f;
        m_minerals.m_oxygen = 200f;
        m_minerals.m_xandry = 100f;
        m_uiController = GetComponent<UIController>();
        m_uiController.m_mineralsUI.UpdateMineralsUI();
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.I))
            AddMineralsAmount(1.1f, 2.1f, 2.1f);
        if (Input.GetKeyDown(KeyCode.K))
            SubstractMineralsAmount(2f, 1.5f, 3f);*/
        UpdateMineralsUI();


    }

    private void UpdateMineralsUI()
    {

        m_uiRefreshTime += Time.deltaTime;



        if (m_uiRefreshTime >= 2f)
        {
            m_uiController.m_mineralsUI.UpdateMineralsUI();
            m_uiRefreshTime = 0f;
        }
    }

    public bool CheckIfEnoughMinerals(float oxygen, float energy, float xandry)
    {
        if (m_minerals.m_oxygen < oxygen || m_minerals.m_energy < energy || m_minerals.m_xandry < xandry)
            return false;
        return true;
    }

    public void AddMineralsAmount(float oxygen, float energy, float xandry)
    {
        m_minerals.m_oxygen += oxygen;
        m_minerals.m_energy += energy;
        m_minerals.m_xandry += xandry;
    }

    public void SubstractMineralsAmount(float oxygen, float energy, float xandry)
    {
        m_minerals.m_oxygen -= oxygen;
        m_minerals.m_energy -= energy;
        m_minerals.m_xandry -= xandry;
    }


}
