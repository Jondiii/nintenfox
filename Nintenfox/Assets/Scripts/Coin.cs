using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject.GetComponent<Renderer>());
            Destroy(gameObject.GetComponent<Collider>());
            audioSource.Play();
            Destroy(gameObject, 1);
        }
    }

}
