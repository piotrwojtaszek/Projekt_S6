using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : BuildingController
{
    public float m_rate = 5f;
    public int m_amount = 2;
    private float m_currTime = 0f;
    public float m_radius = 2f;

    public override void Awake()
    {
        m_radius = m_settings.m_buildColliderSize;
        base.Awake();
    }

    public override void Update()
    {
        base.Update();
        CheckIfMineralsInRange();
    }

    private void CheckIfMineralsInRange()
    {
        if (m_currTime >= m_rate)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, m_radius);
            foreach (Collider col in colliders)
            {
                if (col.gameObject.GetComponent<XandrytController>() != null)
                {
                    if (GameController.Instance.CheckIfEnoughMinerals(m_settings.m_livingCost.m_oxygen, m_settings.m_livingCost.m_energy, 0f))
                        col.gameObject.GetComponent<XandrytController>().CollectXandryt(m_amount);
                }
            }
            if (GameController.Instance.CheckIfEnoughMinerals(m_settings.m_livingCost.m_oxygen, m_settings.m_livingCost.m_energy, m_settings.m_livingCost.m_xandry))
                GameController.Instance.SubstractMineralsAmount(m_settings.m_livingCost.m_oxygen, m_settings.m_livingCost.m_energy, m_settings.m_livingCost.m_xandry);
            m_currTime = 0f;
        }
        m_currTime += Time.deltaTime;

    }

    public override void Interaction()
    {
        Debug.Log("Nastąpiła interakcja z :" + m_settings.m_name);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, m_radius);
    }
}
