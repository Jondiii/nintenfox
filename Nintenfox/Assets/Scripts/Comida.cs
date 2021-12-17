using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{
    private AudioSource aud;
    private MyGameManager gameManager;
    private UpdateUI updateUI;
    
    public GameObject soni;

    
    

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<MyGameManager>();
        updateUI = Object.FindObjectOfType<UpdateUI>();
        aud = soni.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        //Acciones a realizar cuando se detecta una entrada al Trigger.
        if (collider.gameObject.name == "Fox")
        {
            //cuando llegue que espere
            //lanzar la animación 
            Debug.Log("EL ZORRO HA TOCADO LA COMIDA");
            //Destroy(gameObject.GetComponent<Renderer>());
            //Destroy(gameObject.GetComponent<Collider>());

            
            updateUI.UpdateFood(20);
            gameManager.player.energia = gameManager.player.energia + 20;
            gameManager.SaveGame();
            aud.Play();
            gameObject.SetActive(false);
            
            //Destroy(this.gameObject, 1);
            //gameManager.player.energia = hambre;
            //updateUI.UpdateFood(gameManager.player.energia);
        }
    }


}
