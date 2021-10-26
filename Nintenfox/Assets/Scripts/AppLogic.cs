using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppLogic : MonoBehaviour
{

    private static AppLogic instance;

    public static AppLogic Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SampleScene"); //Podemoss poner el nombre de la escena o su ú‹dice (el orden en el que la hemos añadido al build settings
    }
}
