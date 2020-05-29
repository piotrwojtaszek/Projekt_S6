using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XandrytController : MonoBehaviour
{
    [SerializeField]
    private float m_xandryt;

    private void Start()
    {
        m_xandryt = Random.Range(1000f, 1500f);

    }

    public float GetXandrytCurrentAmount()
    {
        return m_xandryt;
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
        if (m_xandryt <= 0)
        {
            Destroy(gameObject);
        }
    }
}
