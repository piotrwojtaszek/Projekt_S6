using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildIngCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    private bool m_isHover = false;
    private S_buildingStats m_building;

    public void OnPointerClick(PointerEventData eventData)
    {
        PlacementController.Instance.DestroyTemporatyPrefab();

        PlacementController.Instance.SetNewCurrentPrefab(m_building.m_model3D);
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_isHover = true;
        if (m_isHover)
            LeanTween.scale(gameObject, Vector3.one * 1.25f, .25f).setEase(UIController.Instance.m_curve);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_isHover = false;
        if (m_isHover == false)
            LeanTween.scale(gameObject, Vector3.one, .25f).setEase(UIController.Instance.m_curve);
    }

    public void SetCard(S_buildingStats buildingController)
    {
        GetComponent<Image>().sprite = buildingController.m_icon;
        m_building = buildingController;

    }
}
