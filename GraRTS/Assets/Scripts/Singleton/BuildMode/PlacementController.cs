using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_placeableObjectPrefab;

    [SerializeField]
    private KeyCode m_newObjectHotKey = KeyCode.A;

    private GameObject m_currentPlaceableObject;

    private void Update()
    {
        HandleNewObjectHotKey();
        if(m_currentPlaceableObject!=null)
        {
            MoveCurrentPlaceableObjectToMouse();
            ReleseIfClicked();
        }
    }

    private void ReleseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_currentPlaceableObject = null;
        }
    }

    private void MoveCurrentPlaceableObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray,out hitInfo))
        {
            m_currentPlaceableObject.transform.position = hitInfo.point;
            m_currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    private void HandleNewObjectHotKey()
    {
        if (Input.GetKeyDown(m_newObjectHotKey))
        {
            if(m_currentPlaceableObject==null)
            {
                m_currentPlaceableObject = Instantiate(m_placeableObjectPrefab);
            }
            else
            {
                Destroy(m_currentPlaceableObject);
            }
        }
    }
}
