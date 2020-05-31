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
    public bool m_mouseOverUI = false;
    private GameObject m_currentSelectedObject = null;
    private float m_uiRefreshTime = 0f;
    private int m_maxBuildings = 10;
    private int m_currBuildingsNumber = 0;
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
        UpdateMineralsUI();
        m_minerals.m_energy = Mathf.Clamp(m_minerals.m_energy, 0f, 1000000000f);
        m_minerals.m_oxygen = Mathf.Clamp(m_minerals.m_oxygen, 0f, 1000000000f);
        m_minerals.m_xandry = Mathf.Clamp(m_minerals.m_xandry, 0f, 1000000000f);
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
        if (m_minerals.m_oxygen - oxygen < 0f || m_minerals.m_energy - energy < 0f || m_minerals.m_xandry - xandry < 0f)
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
    public void SetCurrBuildingNumber(int value)
    {
        m_currBuildingsNumber += value;
        UIController.Instance.m_buildingsDisplayUI.Refresh();
    }
}
