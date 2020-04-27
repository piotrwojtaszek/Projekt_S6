using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControllerBuildMode : MonoBehaviour
{
    public GameObject model;
    public Material badMaterial;
    public Material goodMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UnableToPlace()
    {
        model.GetComponent<Renderer>().material = badMaterial;

    }

    public void AbleToPlace()
    {
        model.GetComponent<Renderer>().material = goodMaterial;
    }

    public void ChangeLayer()
    {
        gameObject.layer = LayerMask.NameToLayer("Building");
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer("Building");
        }
        PlaceOnPlace();
    }

    public void PlaceOnPlace()
    {
        Destroy(GetComponent<ObjectControllerBuildMode>());
    }
}
