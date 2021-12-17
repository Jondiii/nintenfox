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
            Debug.Log("EL ZORRO HA TOCADO LA COMIDA");
     
            updateUI.UpdateFood(20);
            gameManager.player.energia = gameManager.player.energia + 20;
            gameManager.SaveGame();
            aud.Play();
            gameObject.SetActive(false);
        }
    }


}
