using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiadorTienda : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(3);
    }
}
