using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XandryUI : MonoBehaviour
{
    public TextMeshProUGUI m_licnzik;
    public XandrytController m_controller;
    public Image m_image;
    private float m_maxXandryt;
    private void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        m_maxXandryt = m_controller.GetMaxXandrytCurrentAmount();
    }
    // Update is called once per frame
    void Update()
    {
        m_licnzik.text = ((int)m_controller.GetXandrytCurrentAmount()).ToString();
        m_image.fillAmount = m_controller.GetXandrytCurrentAmount() / m_maxXandryt;
        transform.LookAt(Camera.main.transform);
    }
}
