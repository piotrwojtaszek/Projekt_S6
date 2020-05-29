using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public MineralsUI m_mineralsUI;
    public static UIController Instance;
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
