using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : BuildingController
{
    public int m_amount = 2;
    public float m_radius = 2f;

    public override void Awake()
    {
        m_radius = m_settings.m_buildColliderSize;
        base.Awake();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Collect()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, m_radius);
        foreach (Collider col in colliders)
        {
            if (col.gameObject.GetComponent<XandrytController>() != null)
            {
                if (GameController.Instance.CheckIfEnoughMinerals(m_settings.m_livingCost.m_oxygen, m_settings.m_livingCost.m_energy, 0f))
                    col.gameObject.GetComponent<XandrytController>().CollectXandryt(m_amount + (3 * m_level));
            }
        }
        //if (GameController.Instance.CheckIfEnoughMinerals(m_settings.m_livingCost.m_oxygen, m_settings.m_livingCost.m_energy, m_settings.m_livingCost.m_xandry))
        GameController.Instance.SubstractMineralsAmount(m_settings.m_livingCost.m_oxygen, m_settings.m_livingCost.m_energy, m_settings.m_livingCost.m_xandry);

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
