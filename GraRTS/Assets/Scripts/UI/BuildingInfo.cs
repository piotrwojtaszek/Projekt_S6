using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BuildingInfo : MonoBehaviour
{
    private GameObject m_currentObj;
    public Image m_Icon;
    public TextMeshProUGUI m_name;
    public TextMeshProUGUI m_level;
    public Image m_upgrade;
    private BuildingController m_building;
    Color m_baseColor;
    // Start is called before the first frame update
    void Start()
    {
        m_currentObj = GameController.Instance.GetCurrSelectedObject();
        m_building = m_currentObj.GetComponent<BuildingController>();
        m_baseColor = m_upgrade.color;
        m_Icon.sprite = m_building.m_settings.m_icon;
        m_name.text = m_building.m_settings.m_name;
    }

    // Update is called once per frame
    void Update()
    {
        RefreshUI();
    }

    public void CloseUI()
    {
        GameController.Instance.ClearCurrSelectedObject();
        Destroy(gameObject);
    }

    public void Upgarde()
    {

        m_building.Upgrade();
    }

    void RefreshUI()
    {
        if (!GameController.Instance.CheckIfEnoughMinerals
            (m_building.m_settings.m_upgradeCost.m_oxygen * m_building.m_level, m_building.m_settings.m_upgradeCost.m_energy * m_building.m_level, m_building.m_settings.m_upgradeCost.m_xandry * m_building.m_level))
        {
            m_upgrade.color = Color.black;
        }
        else
        {
            m_upgrade.color = m_baseColor;
        }
        m_level.text = m_currentObj.GetComponent<BuildingController>().m_level.ToString();
    }

    public void DestroyBuilding()
    {
        GameController.Instance.SetCurrBuildingNumber(-1,m_building);
        Destroy(m_currentObj.gameObject);
        CloseUI();
    }
}
