using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseOfBuilding",menuName = "MyAssets/Budildings")]
public class BuildingBase : ScriptableObject
{
    public float maxHealth;
    public string name;
    public GameObject model;


    public void Destroy(GameObject obj)
    {
        Destroy(obj);
    }
}
