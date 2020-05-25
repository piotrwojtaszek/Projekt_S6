using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : BuildingController
{
    public override void Interaction() { Debug.Log("Nastąpiła interakcja z :" + m_settings.m_name); }
    public float m_rate=5f;
    private float m_currTime = 0f;
    public float m_radius=2f;
    private void Update()
    {
        CheckIfMineralsInRange();
    }

    private void CheckIfMineralsInRange()
    {
        if(m_currTime>=m_rate)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, m_radius);
            int number = 0;
            foreach(Collider col in colliders)
            {
                if(col.gameObject.GetComponent<XandrytController>()!=null)
                {
                    number++;
                }
            }
            GameController.Instance.AddMineralsAmount(0f, 0f, 2f * number);
        }
        m_currTime += Time.deltaTime;

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, m_radius);
    }
}
