using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Video;

public class BuildingsUI : MonoBehaviour
{
    public S_buildingStats[] m_listOfBuildings;
    public GameObject m_content;
    private GameObject m_buildingCard;
    private void Awake()
    {
        m_buildingCard = Resources.Load("UI/Build/BuildingDisplayCard") as GameObject;

        foreach(S_buildingStats building in m_listOfBuildings)
        {
            GameObject m_cardPrefab = Instantiate(m_buildingCard, m_content.transform);
            m_cardPrefab.GetComponent<BuildIngCard>().SetCard(building.m_icon);
        }
    }


}
