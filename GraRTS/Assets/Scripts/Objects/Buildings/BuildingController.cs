using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public BuildingBase buildingBase;
    private float currentHealth;
    private float maxHealth;
    private void Awake()
    {
        maxHealth = buildingBase.maxHealth;
        currentHealth = maxHealth;
    }

    private void OnMouseDown()
    {
        Interaction();
    }

    public virtual void Interaction()
    {
        Debug.Log("jakas interakcja");
    }
}
