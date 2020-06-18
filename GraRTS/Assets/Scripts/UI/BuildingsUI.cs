using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingsUI : MonoBehaviour
{
    public S_buildingStats[] m_listOfBuildings;
    public GameObject m_content;
    private GameObject m_buildingCard;

    public GameObject m_buildButton;
    public GameObject m_buildingsContainer;
    private bool m_animRunning;
    private bool m_buildMenu = false;
    private void Awake()
    {
        m_buildingCard = Resources.Load("UI/Build/BuildingDisplayCard") as GameObject;
        foreach (Transform tra in m_content.transform)
        {
            Destroy(tra.gameObject);
        }
        GameObject m_cardPrefab = Instantiate(m_buildingCard, m_content.transform);
        m_cardPrefab.GetComponent<BuildIngCard>().SetCard(m_listOfBuildings[0]);

    }

    public void SwitchBuildMenu()
    {
        if (m_buildMenu)
            DisableBuildMenu();
        else
            EnableBuildMenu();
    }

    public void EnableBuildMenu()
    {
        if (m_animRunning == false)
        {
            LeanTween.moveLocalY(m_buildButton, 310f, 1f).setEase(UIController.Instance.m_curve).setOnStart(StartAnim).setOnComplete(EndAnim);
            LeanTween.moveLocalY(m_buildingsContainer, 0f, 1f).setEase(UIController.Instance.m_curve).setOnStart(StartAnim).setOnComplete(EndAnim);
            m_buildButton.GetComponentInChildren<BuildButton>().ArrowDown();
            m_buildMenu = true;
        }
    }

    public void DisableBuildMenu()
    {
        if (m_animRunning == false)
        {
            LeanTween.moveLocalY(m_buildButton, 0f, 1f).setEase(UIController.Instance.m_curve).setOnStart(StartAnim).setOnComplete(EndAnim);
            LeanTween.moveLocalY(m_buildingsContainer, -410f, 1f).setEase(UIController.Instance.m_curve).setOnStart(StartAnim).setOnComplete(EndAnim);
            m_buildButton.GetComponentInChildren<BuildButton>().ArrowUp();
            m_buildMenu = false;
        }
    }

    void EndAnim()
    {
        m_animRunning = false;
    }

    void StartAnim()
    {
        m_animRunning = true;
    }

    public void ChangeCards()
    {
        foreach (Transform child in m_content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        for (int i = 1; i < m_listOfBuildings.Length; i++)
        {
            GameObject m_cardPrefab = Instantiate(m_buildingCard, m_content.transform);
            m_cardPrefab.GetComponent<BuildIngCard>().SetCard(m_listOfBuildings[i]);
        }

    }

}
