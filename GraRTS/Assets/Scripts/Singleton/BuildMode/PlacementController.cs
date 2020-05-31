using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    public static PlacementController Instance;

    [SerializeField]
    private GameObject m_placeableObjectPrefab;

    [SerializeField]
    private KeyCode m_newObjectHotKey = KeyCode.A;

    private GameObject m_currentPlaceableObject;
    private GameObject m_collisionSphere = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        HandleNewObjectHotKey();
        if (m_currentPlaceableObject != null && !GameController.Instance.m_mouseOverUI)
        {
            MoveCurrentPlaceableObjectToMouse();
            ReleseIfClicked();
        }
    }

    private void ReleseIfClicked()
    {
        BuildingController building = m_currentPlaceableObject.GetComponent<BuildingController>();
        if (CheckCanPlace(building))
            if (Input.GetMouseButtonDown(0))
            {
                DestoryTemporaryCollisionSphere();
                m_currentPlaceableObject = null;
                building.m_settings.CreateCost();
                building.ShaderChangeBase();
                building.ColliderOn();
                building.SetPlaced(true);
                building = null;

            }

    }

    private void MoveCurrentPlaceableObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            m_currentPlaceableObject.transform.position = hitInfo.point;
            m_currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    public void HandleNewObjectHotKey()
    {
        if (Input.GetKeyDown(m_newObjectHotKey) || Input.GetKeyDown(KeyCode.Mouse1))
            DestroyTemporatyPrefab();

    }

    public void DestroyTemporatyPrefab()
    {
        if (m_currentPlaceableObject != null)
            Destroy(m_currentPlaceableObject);
    }

    public void SetNewCurrentPrefab(GameObject prefab)
    {
        m_placeableObjectPrefab = prefab;
        m_currentPlaceableObject = Instantiate(m_placeableObjectPrefab);
    }

    private bool CheckCanPlace(BuildingController building)
    {
        TemporaryCollisionSphere(building);

        int layerMask = 1 << 9;
        Collider[] colliders = Physics.OverlapSphere(building.transform.position, building.m_settings.m_buildColliderSize, layerMask);

        if (colliders.Length > 0 || !GameController.Instance.CheckIfEnoughMinerals(building.m_settings.m_createCost.m_oxygen, building.m_settings.m_createCost.m_energy, building.m_settings.m_createCost.m_xandry))
        {
            building.ShaderChangeBad();
            return false;
        }
        building.ShaderChangeGood();
        return true;
    }

    private void TemporaryCollisionSphere(BuildingController building)
    {
        if(m_collisionSphere==null)
        {
            GameObject spherePrefab = Resources.Load("General/Useful/CollisionSphere") as GameObject;

            m_collisionSphere = Instantiate(spherePrefab, m_currentPlaceableObject.transform) as GameObject;

            m_collisionSphere.transform.localScale = Vector3.one * building.m_settings.m_buildColliderSize*2f;
        }
    }

    private void DestoryTemporaryCollisionSphere()
    {
        Destroy(m_collisionSphere);
    }

}
