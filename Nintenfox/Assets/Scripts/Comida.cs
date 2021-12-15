using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{
    private AudioSource audioSource;
    //public MyGameManager gameManager;
    //public UpdateUI updateUI;
    //float hambre = 0;
    public GameObject zorro;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        //Acciones a realizar cuando se detecta una entrada al Trigger.
        if (collider.gameObject.name == "Fox")
        {
            //cuando llegue que espere
            //lanzar la animación 
            Debug.Log("EL ZORRO HA TOCADO LA COMIDA");
            Destroy(gameObject.GetComponent<Renderer>());
            Destroy(gameObject.GetComponent<Collider>());
            audioSource.Play();
            Destroy(gameObject, 1);
            //gameManager.player.energia = hambre;
            //updateUI.UpdateFood(gameManager.player.energia);
        }
    }


}
