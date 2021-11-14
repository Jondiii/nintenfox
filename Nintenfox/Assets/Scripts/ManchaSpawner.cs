using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManchaSpawner : MonoBehaviour
{
    // Este atributo es público, desde la escena de Unity podréis arrastrar aquí las esferas de suciedad
    public GameObject[] dirtBalls;

    public GameObject fox;

    int currentDirtBall = 0;

    private float elapsedTime;

    private Rigidbody playerRigibody;


    private void Awake()
    {
        // Hacer que al principio estén todas las manchas desactivadas
        for (int i = 0; i < dirtBalls.Length; i++)
        {
            dirtBalls[i].SetActive(false);
            playerRigibody = GetComponent<Rigidbody>();
        }
    }
    private void Update()
    {
        if (currentDirtBall > dirtBalls.Length * 10)
        {
            // Ya se han activado todas las bolitas de suciedad
            Debug.Log("El lobo esta muy sucio");
            currentDirtBall = 0;
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
                dirtBalls[i].SetActive(true);
                var go = Instantiate<GameObject>(dirtBalls[i]);
                float x = Random.Range(fox.transform.position.x - 0.05f, fox.transform.position.x + 0.05f);
                float y = Random.Range(fox.transform.position.y, fox.transform.position.y + 0.15f);
                float z = Random.Range(fox.transform.position.z - 0.05f, fox.transform.position.z + 0.05f);

                go.transform.position = new Vector3(x, y, z);
                go.transform.SetParent(fox.transform);

                // Restamos un segundo
                currentDirtBall++;
                elapsedTime--;
            }
        }
    }

    public void ManchaEliminada()
    {
        currentDirtBall--;
        Debug.Log("Mancha Limpiada");
        Debug.Log("Total manchas: " + currentDirtBall);
    }

    private void OnEnable()
    {

    }
}
