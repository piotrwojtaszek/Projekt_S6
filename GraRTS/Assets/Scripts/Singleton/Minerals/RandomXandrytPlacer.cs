using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomXandrytPlacer : MonoBehaviour
{
    private void Awake()
    {
        GameObject prefab = Resources.Load("Prefabs/Naturals/XandrytPrefab") as GameObject;

        for(int i =-85; i<100;i+=15)
        {
            for(int j = -85;j<100;j+=15)
            {
                if(Random.Range(-5f,1f)>0f)
                {
                    GameObject obj = Instantiate(prefab);
                    obj.transform.position = new Vector3(i, 0f, j);
                }
                else
                {
                    GetComponent<RandomDetailsPlacer>().WylosujDetale(new Vector3(i, 0f, j));
                }
            }
        }
        Destroy(gameObject);
    }
}
