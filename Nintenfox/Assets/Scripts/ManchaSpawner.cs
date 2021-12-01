using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManchaSpawner : MonoBehaviour
{
    // Este atributo es p�blico, desde la escena de Unity podr�is arrastrar aqu� las esferas de suciedad
    public GameObject[] dirtBalls;

    public GameObject fox;

    float currentDirtBall = 0;

    private float elapsedTime;

    private Rigidbody playerRigibody;

    public MyGameManager gameManager;

    private void Awake()
    {
        // Hacer que al principio est�n todas las manchas desactivadas
        for (int i = 0; i < dirtBalls.Length; i++)          //salta fallo
        {
            dirtBalls[i].SetActive(false);
            playerRigibody = GetComponent<Rigidbody>();
        }
    }
    private void Update()
    {
        if (currentDirtBall > dirtBalls.Length * 10 && dirtBalls.Length < 100)
        {
            // Ya se han activado todas las bolitas de suciedad
            Debug.Log("El lobo esta muy sucio");
            //currentDirtBall = 0;
            return;
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 10)
        {
            // Ha pasado 10 segundos...
            for (int i = 0; i < dirtBalls.Length; i++)
            {
                Debug.Log("Aparecio una mancha");
                Debug.Log("Total manchas: " + currentDirtBall);
                gameManager.player.limpieza = currentDirtBall;
                Debug.Log("Ahora tienes " + gameManager.player.limpieza + " manchas");
                dirtBalls[i].SetActive(true);
                var go = Instantiate<GameObject>(dirtBalls[i]);
                float x = Random.Range(fox.transform.position.x - 0.05f, fox.transform.position.x + 0.05f);
                float y = Random.Range(fox.transform.position.y, fox.transform.position.y + 0.15f);
                float z = Random.Range(fox.transform.position.z - 0.05f, fox.transform.position.z + 0.05f);

                go.transform.position = new Vector3(x, y, z);
                go.transform.SetParent(fox.transform);
                //Evento
                var mancha = go.GetComponent<Mancha>();
                mancha.OnCleaner += Mancha_OnCleaner;
                
                currentDirtBall++;
                // Restamos un segundo
                elapsedTime--;
            }
        }
    }

    private void Mancha_OnCleaner()
    {
        ManchaEliminada();
    }

    public void ManchaEliminada()
    {
        currentDirtBall--;
        Debug.Log("Mancha Limpiada");
        Debug.Log("Total manchas: " + currentDirtBall);
        gameManager.player.limpieza = currentDirtBall;
        Debug.Log("Ahora tienes " + gameManager.player.limpieza + " manchas");
    }
}
