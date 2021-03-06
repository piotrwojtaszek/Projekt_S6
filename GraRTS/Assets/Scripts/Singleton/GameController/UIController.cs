﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    public GameObject m_Menu;
    public MineralsUI m_mineralsUI;
    public BuildingsUI m_buildingUI;
    public BuildingsDisplay m_buildingsDisplayUI;

    
    public AnimationCurve m_curve;
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
    }
    public void MouseHoverUI()
    {
        GameController.Instance.m_mouseOverUI = true;
    }

    public void MouseExitUI()
    {
        GameController.Instance.m_mouseOverUI = false;
    }

}
