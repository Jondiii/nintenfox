using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void onEnable()
    {
        Debug.Log("ESTA LA MANZANA EN ESCENA");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Fox")
        {
            Debug.Log("COLISION ENTRE ZORRO Y COMIDA");
            Destroy(gameObject.GetComponent<Renderer>());
            Destroy(gameObject.GetComponent<Collider>());
            audioSource.Play();
            Destroy(gameObject, 1);
        }
    }


}
