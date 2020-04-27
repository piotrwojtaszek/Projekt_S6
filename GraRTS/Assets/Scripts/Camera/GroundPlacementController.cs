using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPlacementController : MonoBehaviour
{

    [SerializeField]
    private GameObject placeableObjectPrefab;
    [SerializeField]
    private KeyCode newObjectHotkey = KeyCode.A;
    private GameObject currentPlaceableObject;
    private float mouseWheelRotation;
    [SerializeField]
    private LayerMask collisionMask;

    // Update is called once per frame
    void Update()
    {
        HandleNewObjectHotkey();  
        if(currentPlaceableObject !=null)
        {
            MoveCurrentPlaceableObjectToMouse();
            RotateFromMouseWheel();
            RealseIfClicked();
        }
    }

    private void RealseIfClicked()
    {
       

        if (Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject.GetComponent<ObjectControllerBuildMode>().ChangeLayer();
            currentPlaceableObject = null;

        }
    }

    private void RotateFromMouseWheel()
    {
        mouseWheelRotation += Input.mouseScrollDelta.y;
        currentPlaceableObject.transform.Rotate(Vector3.up, mouseWheelRotation * 10f);
    }

    private void MoveCurrentPlaceableObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hitInfo;

        if(Physics.Raycast(ray,out hitInfo,Mathf.Infinity,collisionMask))
        {

            currentPlaceableObject.transform.position = hitInfo.point;
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            Collider[] hitColliders = Physics.OverlapSphere(currentPlaceableObject.transform.position, 1f,collisionMask);
            if(hitColliders.Length>1)
            {
                currentPlaceableObject.GetComponent<ObjectControllerBuildMode>().UnableToPlace();

                foreach (Collider col in hitColliders)
                {
                    Debug.Log(col.name);
                }
            }
            else
            {
                currentPlaceableObject.GetComponent<ObjectControllerBuildMode>().AbleToPlace();
            }
        }
    }

    private void HandleNewObjectHotkey()
    {
        if(Input.GetKeyDown(newObjectHotkey))
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
