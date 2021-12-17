using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public GameObject esponja;

    private void Awake()
    {
        esponja.SetActive(false);
    }

    private void OnMouseDown()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MenuPrincipal")
        {
            esponja.SetActive(true);
        }
    }
}
