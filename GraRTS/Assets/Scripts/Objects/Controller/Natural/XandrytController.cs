using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class XandrytController : MonoBehaviour
{
    [SerializeField]
    private float m_xandryt;
    private float m_maxXandryt;
    private GameObject m_ui;
    public GameObject m_prefab;
    private void Start()
    {
        m_maxXandryt = Random.Range(2000f, 3500f);
        m_xandryt = m_maxXandryt;
    }

    public float GetXandrytCurrentAmount()
    {
        return m_xandryt;
    }
    public float GetMaxXandrytCurrentAmount()
    {
        return m_maxXandryt;
    }

    public void CollectXandryt(int amount)
    {
        if (amount >= m_xandryt)
        {
            amount = (int)m_xandryt;
            m_xandryt -= amount;
            GameController.Instance.AddMineralsAmount(0f, 0f, amount);
            DestroMe();
        }
        else
        {
            m_xandryt -= amount;
            GameController.Instance.AddMineralsAmount(0f, 0f, amount);
        }
    }

    void DestroMe()
    {
        if ((int)m_xandryt <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseEnter()
    {
        Debug.Log("stworz bar");
        m_ui = Instantiate(m_prefab, transform);
        m_ui.transform.position += new Vector3(0f, 10f, 0f);
        m_ui.transform.localScale = m_ui.transform.localScale / transform.localScale.x;
        m_ui.GetComponent<XandryUI>().m_controller = this;
    }

    private void OnMouseExit()
    {
        if (m_ui != null)
            Destroy(m_ui);
        Debug.Log("zniszcz bar");
    }
}
