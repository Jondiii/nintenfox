using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class CambiadorJuego : MonoBehaviour
{
    public float cantidad;
    public MyGameManager gameManager;
    public UpdateUI updateUI;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Fox")
        {
            
            if (gameManager.player.energia > 0)
            {
                gameManager.player.energia = gameManager.player.energia - cantidad;
                updateUI.UpdateFood(-cantidad);
                gameManager.SaveGame();
                //Debug.Log("RESTOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
                //SceneManager.LoadScene(2);

            }
                     

        }

    }
    
}
