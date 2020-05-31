using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BuildingsDisplay : MonoBehaviour
{
    public TextMeshProUGUI m_current;
    public TextMeshProUGUI m_max;

    public void Refresh()
    {
        m_current.text = GameController.Instance.GetCurrentBuildingsNumber().ToString();
        m_max.text = GameController.Instance.GetMaxBuildingsNumber().ToString();
    }

}
