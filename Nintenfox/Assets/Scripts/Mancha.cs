using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mancha : MonoBehaviour
{
    private AudioSource audioSource;

    private ManchaSpawner manchaSpawer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        manchaSpawer = GetComponent<ManchaSpawner>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Colision entre zorro y mancha");

        if (collision.gameObject.tag == "Limpiar")
        {
            Debug.Log("Colision entre zorro y mancha2");
            Destroy(gameObject.GetComponent<Renderer>());
            Destroy(gameObject.GetComponent<Collider>());
            audioSource.Play();
            Destroy(gameObject, 1);
            manchaSpawer.ManchaEliminada(collision.gameObject);
        }
    }
}
