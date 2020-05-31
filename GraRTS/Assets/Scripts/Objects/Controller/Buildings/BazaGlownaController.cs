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
            GameController.Instance.AddMineralsAmount(m_amount + (3 * m_level), m_amount + (3 * m_level), m_amount + (3 * m_level));
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
}