using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{
    private AudioSource aud;
    private MyGameManager gameManager;
    private UpdateUI updateUI;
    
    public GameObject soni;
    public int energiaRecuperada;

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
            if (!(gameManager.player.energia + energiaRecuperada > 100))
            {
                updateUI.UpdateFood(energiaRecuperada);
                gameManager.player.energia = gameManager.player.energia + energiaRecuperada;
                gameManager.SaveGame();
                aud.Play();
                gameObject.SetActive(false);
            }
            
            Debug.Log("Ha llegado a la comida");
     

        }
    }


}
