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
        m_xandryt -= amount;
    }
}
