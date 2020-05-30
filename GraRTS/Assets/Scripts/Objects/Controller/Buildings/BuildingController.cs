using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : Interactable
{
    public S_buildingStats m_settings;
    public float m_currHealth;
    public GameObject m_modelPrefab;
    //public override void Interaction() { Debug.Log("Nastąpiła interakcja z :"+m_settings.m_name); }
    private Shader m_baseShader;

    public virtual void Awake()
    {
        m_currHealth = m_settings.m_maxHealth;
        m_baseShader = m_modelPrefab.GetComponent<Renderer>().material.shader;
        ShaderChangeBase();
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

    public void ShaderChangeBad()
    {
        Renderer m_renderer = m_modelPrefab.GetComponent<Renderer>();
        Material[] m_materials = m_renderer.materials;
        List<Material> m_materialsList = new List<Material>();
        foreach(Material mat in m_materials)
        {
            mat.shader = Shader.Find("Shader Graphs/Red");
        }
    }

    public void ShaderChangeGood()
    {
        Renderer m_renderer = m_modelPrefab.GetComponent<Renderer>();
        Material[] m_materials = m_renderer.materials;
        List<Material> m_materialsList = new List<Material>();
        foreach (Material mat in m_materials)
        {
            mat.shader = Shader.Find("Shader Graphs/Green");
        }
    }

    public void ShaderChangeBase()
    {
        Renderer m_renderer = m_modelPrefab.GetComponent<Renderer>();
        Material[] m_materials = m_renderer.materials;
        List<Material> m_materialsList = new List<Material>();
        foreach (Material mat in m_materials)
        {
            mat.shader = m_baseShader;
        }
    }

    public void ColliderOn()
    {
        GetComponent<Collider>().enabled = true;
    }



}
