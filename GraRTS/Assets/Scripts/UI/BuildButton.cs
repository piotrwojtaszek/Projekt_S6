using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButton : MonoBehaviour
{
    public void SwitchMode()
    {
        Debug.Log("Dziala");
        GameController gm = Resources.Load("GM/GameMenager") as GameController;
        gm.buildMode = !gm.buildMode;
    }
}
