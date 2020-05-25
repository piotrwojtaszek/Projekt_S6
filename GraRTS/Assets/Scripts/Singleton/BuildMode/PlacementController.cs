using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    [SerializeField]
    private GameObject placeableObjectPrefab;

    [SerializeField]
    private KeyCode newObjectHotKey = KeyCode.A;

    private GameObject currentPlaceableObject;

    private void Update()
    {
        HandleNewObjectHotKey();
        if(currentPlaceableObject!=null)
        {
            MoveCurrentPlaceableObjectToMouse();
            ReleseIfClicked();
        }
    }

    private void ReleseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject = null;
        }
    }

    private void MoveCurrentPlaceableObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray,out hitInfo))
        {
            currentPlaceableObject.transform.position = hitInfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    private void HandleNewObjectHotKey()
    {
        if (Input.GetKeyDown(newObjectHotKey))
        {
            if(currentPlaceableObject==null)
            {
                currentPlaceableObject = Instantiate(placeableObjectPrefab);
            }
            else
            {
                Destroy(currentPlaceableObject);
            }
        }
    }
}
