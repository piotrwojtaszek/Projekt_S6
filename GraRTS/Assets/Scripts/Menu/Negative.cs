using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Negative : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    Image m_image;
    TextMeshProUGUI m_text;
    public Color m_negativColor;
    public Color m_baseColor;
    public Color m_negativColorText;
    public Color m_baseColorText;
    public float m_sizeOnHover;
    public float m_time;
    Vector3 m_baseScale;
    public AnimationCurve m_animationCurve;
    private void Start()
    {
        m_baseScale = transform.localScale;
        m_image = GetComponent<Image>();
        m_text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_image.color = m_negativColor;
        m_text.color = m_negativColorText;
        LeanTween.scale(gameObject, m_baseScale * m_sizeOnHover, m_time).setEase(m_animationCurve);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_image.color = m_baseColor;
        m_text.color = m_baseColorText;
        LeanTween.scale(gameObject, m_baseScale, m_time).setEase(m_animationCurve);
    }
}
