using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomXandrytPlacer : MonoBehaviour
{
    private void Awake()
    {
        GameObject prefab = Resources.Load("Prefabs/Naturals/XandrytPrefab") as GameObject;

        for(int i =0; i<100;i+=5)
        {
            for(int j = 0;j<100;j+=5)
            {
                if(Random.Range(-3f,1f)>0f)
                {
                    GameObject obj = Instantiate(prefab);
                    obj.transform.position = new Vector3(i, 0f, j);
                }    
            }
        }
        Destroy(gameObject);

    }
}
