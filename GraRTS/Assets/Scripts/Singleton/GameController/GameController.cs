﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public Minerals m_minerals;
    [HideInInspector]
    public UIController m_uiController;
    public bool m_mouseOverUI = false;
    private GameObject m_currentSelectedObject = null;
    private float m_uiRefreshTime = 0f;
    private int m_maxBuildings = 10;
    private int m_currBuildingsNumber = 0;
    public float m_currTime = 0f;
    public List<BuildingController> m_buildingsList = new List<BuildingController>();
    public GameObject m_menuUI;
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

        m_minerals.m_energy = 40f;
        m_minerals.m_oxygen = 100f;
        m_minerals.m_xandry = 110f;
        m_uiController = GetComponent<UIController>();
        m_uiController.m_mineralsUI.UpdateMineralsUI();
    }

    private void Start()
    {
        UIController.Instance.m_buildingsDisplayUI.Refresh();
    }

    private void Update()
    {
        CollectMinerals();

        UpdateMineralsUI();
        m_minerals.m_energy = Mathf.Clamp(m_minerals.m_energy, 0f, 1000000000f);
        m_minerals.m_oxygen = Mathf.Clamp(m_minerals.m_oxygen, 0f, 1000000000f);
        m_minerals.m_xandry = Mathf.Clamp(m_minerals.m_xandry, 0f, 1000000000f);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            m_menuUI.SetActive(!m_menuUI.activeSelf);
        }
    }

    private void CollectMinerals()
    {
        m_currTime += Time.deltaTime;
        if (m_currTime >= 2f)
        {
            foreach(BuildingController building in m_buildingsList)
            {
                building.Collect();
            }

            m_currTime = 0f;
        }
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

    public void UIUpdate()
    {
        m_uiController.m_mineralsUI.UpdateMineralsUI();
    }

    /// <summary>
    /// Zwraca false gdy za malo, true gdy wystarczy
    /// </summary>
    /// <param name="oxygen"></param>
    /// <param name="energy"></param>
    /// <param name="xandry"></param>
    /// <returns></returns>
    public bool CheckIfEnoughMinerals(float oxygen, float energy, float xandry)
    {
        if (m_minerals.m_oxygen - oxygen <= 0f || m_minerals.m_energy - energy <= 0f || m_minerals.m_xandry - xandry <= 0f)
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
        m_uiController.m_mineralsUI.UpdateMineralsUI();
    }

    public void SetCurrSelectedObject(GameObject obj)
    {
        m_currentSelectedObject = obj;
        m_currentSelectedObject.GetComponent<BuildingController>().ShaderChangeGood();
    }
    public void ClearCurrSelectedObject()
    {
        m_currentSelectedObject.GetComponent<BuildingController>().ShaderChangeBase();
        m_currentSelectedObject = null;
    }
    public GameObject GetCurrSelectedObject()
    {
        return m_currentSelectedObject;
    }

    public int GetMaxBuildingsNumber()
    {
        return m_maxBuildings;
    }

    /// <summary>
    /// Arg >0 znaczy dadaj, Arg <0 znaczy odjac
    /// </summary>
    /// <param name="value"></param>
    public void SetMaxBuildingsNumber(int value)
    {
        m_maxBuildings += value;
        UIController.Instance.m_buildingsDisplayUI.Refresh();
    }

    public int GetCurrentBuildingsNumber()
    {
        return m_currBuildingsNumber;
    }

    /// <summary>
    /// Arg >0 znaczy dadaj, Arg <0 znaczy odjac
    /// </summary>
    /// <param name="value"></param>
    public void SetCurrBuildingNumber(int value, BuildingController building)
    {
        m_currBuildingsNumber += value;
        UIController.Instance.m_buildingsDisplayUI.Refresh();
        if(value>0)
        {
            m_buildingsList.Add(building);
        }
        else
        {
            m_buildingsList.Remove(building);
        }
    }
}
