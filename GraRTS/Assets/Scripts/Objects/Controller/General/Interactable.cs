using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interaction() { Debug.Log("Nastąpiła wirtualna interakcja"); }
}
