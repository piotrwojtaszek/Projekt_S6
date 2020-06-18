using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDetailsPlacer : MonoBehaviour
{
    public GameObject m_container;
    public GameObject[] m_prefabs;

    public void WylosujDetale(Vector3 pozycja)
    {
        for (int k = 0; k <= Random.Range(3, 7); k++)
        {
            int losulosu = Random.Range(0, m_prefabs.Length);
            GameObject obj = Instantiate(m_prefabs[losulosu]);
            Vector2 losu = Random.insideUnitCircle * 10f;
            obj.transform.position = new Vector3(pozycja.x + losu.x, 0f, pozycja.z + losu.y);
            obj.transform.localScale = obj.transform.localScale / 5f;
            Destroy(obj.GetComponent<MeshCollider>());
            //obj.transform.position = new Vector3(i, 0f, j);
        }
    }
}
