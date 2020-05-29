using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIControllerPanel : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIController.Instance.MouseHoverUI();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIController.Instance.MouseExitUI();
    }
}
