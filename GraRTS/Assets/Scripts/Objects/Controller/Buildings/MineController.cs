using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : BuildingController
{
    public override void Interaction() { Debug.Log("Nastąpiła interakcja z :" + m_settings.m_name); }
}
