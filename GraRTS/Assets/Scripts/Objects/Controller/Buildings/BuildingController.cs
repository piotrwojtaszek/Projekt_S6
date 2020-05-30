using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : Interactable
{
    public S_buildingStats m_settings;
    public float m_currHealth;
    //public override void Interaction() { Debug.Log("Nastąpiła interakcja z :"+m_settings.m_name); }


    public virtual void Awake()
    {
        m_currHealth = m_settings.m_maxHealth;
    }

    public virtual void Update()
    {
        DestroyMe();
    }

    public virtual void DestroyMe()
    {
        if (m_currHealth<=0)
        {
            Destroy(gameObject);
        }
    }

}
