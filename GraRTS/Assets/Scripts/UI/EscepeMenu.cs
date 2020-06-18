using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscepeMenu : MonoBehaviour
{
    public void Resume()
    {
        gameObject.SetActive(false);
    }

    public void GoToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
