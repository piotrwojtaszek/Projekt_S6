using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : Interactable
{
    public S_buildingStats m_settings;

    public override void Interaction() { Debug.Log("Nastąpiła interakcja z :"+m_settings.m_name); }
}
