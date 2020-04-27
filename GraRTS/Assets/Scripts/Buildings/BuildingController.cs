using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public BuildingBase buildingBase;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float maxHealth;
    private void Awake()
    {
        maxHealth = buildingBase.maxHealth;
        currentHealth = maxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
