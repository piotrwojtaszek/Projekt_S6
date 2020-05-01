using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayMode : MonoBehaviour
{
    [SerializeField]
    Image obj;
    GameController gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = Resources.Load("GM/GameMenager") as GameController;

    }

    // Update is called once per frame
    void Update()
    {
        if(gm.buildMode)
        {
            obj.color = Color.red;
        }
        else
        {
            obj.color = Color.blue;
        }
    }
}
