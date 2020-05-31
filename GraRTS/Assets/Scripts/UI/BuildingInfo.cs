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
    private BuildingController building;
    Color m_baseColor;
    // Start is called before the first frame update
    void Start()
    {
        m_currentObj = GameController.Instance.GetCurrSelectedObject();
        building = m_currentObj.GetComponent<BuildingController>();
        m_baseColor = m_upgrade.color;
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

        if (GameController.Instance.CheckIfEnoughMinerals
            (building.m_settings.m_upgradeCost.m_oxygen * building.m_level, building.m_settings.m_upgradeCost.m_energy * building.m_level, building.m_settings.m_upgradeCost.m_xandry * building.m_level))
        {
            GameController.Instance.SubstractMineralsAmount(building.m_settings.m_upgradeCost.m_oxygen * building.m_level, building.m_settings.m_upgradeCost.m_energy * building.m_level, building.m_settings.m_upgradeCost.m_xandry * building.m_level);
            m_currentObj.GetComponent<BuildingController>().m_level++;
        }
    }

    void RefreshUI()
    {
        if (!GameController.Instance.CheckIfEnoughMinerals
            (building.m_settings.m_upgradeCost.m_oxygen * building.m_level, building.m_settings.m_upgradeCost.m_energy * building.m_level, building.m_settings.m_upgradeCost.m_xandry * building.m_level))
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
        GameController.Instance.SetCurrBuildingNumber(-1);
        Destroy(m_currentObj.gameObject);
        CloseUI();
    }
}
