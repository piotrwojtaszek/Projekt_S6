using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : Interactable
{
    public S_buildingStats m_settings;
    public float m_currHealth;
    public int m_level = 0;
    public GameObject m_modelPrefab;
    //public override void Interaction() { Debug.Log("Nastąpiła interakcja z :"+m_settings.m_name); }
    private Shader m_baseShader;
    private bool m_placed = false;

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

    public virtual void Collect() { }

    public virtual void DestroyMe()
    {
        if (m_currHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ShaderChangeBad()
    {
        Renderer m_renderer = m_modelPrefab.GetComponent<Renderer>();
        Material[] m_materials = m_renderer.materials;
        List<Material> m_materialsList = new List<Material>();
        foreach (Material mat in m_materials)
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

    public virtual void SetPlaced(bool value)
    {
        m_placed = value;
    }

    public bool GetPlaced()
    {
        return m_placed;
    }

    private void OnMouseOver()
    {
        // może zmienic mu shader na np. żółty
        Debug.Log("Mysz nad budynkiem");
    }

    private void OnMouseUpAsButton()
    {
        // wyswietlic UI
        if (GameController.Instance.GetCurrSelectedObject() == null)
        {
            GameController.Instance.SetCurrSelectedObject(this.gameObject);
            GameObject temp = Resources.Load("UI/Buildings/BuildingInfo") as GameObject;
            Instantiate(temp, UIController.Instance.m_Menu.transform);
            Debug.Log("Kliknięcie budynku");
        }
    }

    public virtual void Upgrade()
    {
        if (CurrentUpgradeCost())
        {
            GameController.Instance.SubstractMineralsAmount(m_settings.m_upgradeCost.m_oxygen * m_level, m_settings.m_upgradeCost.m_energy * m_level, m_settings.m_upgradeCost.m_xandry * m_level);
            m_level++;
        }
    }

    public virtual bool CurrentUpgradeCost()
    {
        if (GameController.Instance.CheckIfEnoughMinerals
    (m_settings.m_upgradeCost.m_oxygen * m_level, m_settings.m_upgradeCost.m_energy * m_level, m_settings.m_upgradeCost.m_xandry * m_level))
            return true;
        return false;
    }
}
