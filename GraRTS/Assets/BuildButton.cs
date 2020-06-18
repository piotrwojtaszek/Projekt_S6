using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public void ArrowUp()
    {//90
        LeanTween.rotate(gameObject, new Vector3(0f, 0f, 90f), 1f).setEase(UIController.Instance.m_curve);
    }

    public void ArrowDown()
    {//-90
        LeanTween.rotate(gameObject, new Vector3(0f, 0f, -90f), 1f).setEase(UIController.Instance.m_curve);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(this.gameObject, Vector3.one * 1.2f, 0.3f).setEase(UIController.Instance.m_curve);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(this.gameObject, Vector3.one*0.8f, 0.3f).setEase(UIController.Instance.m_curve);
    }
}
