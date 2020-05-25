using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MineralsUI : MonoBehaviour
{
    public TextMeshProUGUI m_energy;
    public TextMeshProUGUI m_oxygen;
    public TextMeshProUGUI m_xandryt;

    public void UpdateMineralsUI()
    {
        m_energy.text = (GameController.Instance.m_minerals.m_energy).ToString("F0");
        m_oxygen.text = (GameController.Instance.m_minerals.m_oxygen).ToString("F0");
        m_xandryt.text = (GameController.Instance.m_minerals.m_xandry).ToString("F0");
    }
}
