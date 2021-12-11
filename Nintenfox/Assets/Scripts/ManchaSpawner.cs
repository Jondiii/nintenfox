using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManchaSpawner : MonoBehaviour
{
    // Este atributo es público, desde la escena de Unity podréis arrastrar aquí las esferas de suciedad
    public GameObject[] dirtBalls;

    public GameObject fox;

    float currentDirtBall = 0;

    private float elapsedTime;

    private Rigidbody playerRigibody;

    public MyGameManager gameManager;

    public UpdateUI updateUI;

    public int fontSize = 18;

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
        if (currentDirtBall > 99 && dirtBalls.Length < 100)
        {
            // Ya se han activado todas las bolitas de suciedad
            Debug.Log("El zorro esta muy sucio");
            return;
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 30)
        {
            // Ha pasado 30 segundos...
            for (int i = 0; i < dirtBalls.Length; i++)
            {
                Debug.Log("Aparecio una mancha");
                Debug.Log("Total manchas: " + currentDirtBall);
                gameManager.player.limpieza = currentDirtBall;
                updateUI.UpdateCleaniness(gameManager.player.limpieza);
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
        updateUI.UpdateCleaniness(gameManager.player.limpieza);
        Debug.Log("Ahora tienes " + gameManager.player.limpieza + " manchas");
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = fontSize;
        //if (currentDirtBall >= 50 && currentDirtBall < 80)
        //{
        //    GUI.color = Color.yellow;
        //}
        //else
        //{
        GUI.color = Color.blue;
        //if (currentDirtBall >= 80)
          //  {
                //GUI.color = Color.red;
                if (currentDirtBall == 100)
                {
                   GUI.Label(new Rect(450, 300, 200, 25), "El Zorro esta muy Sucio");
                }
            //}
            //else
            //{
                
            //}
        //}
        GUI.Label(new Rect(210, 25, 200, 25), ((int)currentDirtBall + "%")); 
    }
}
