using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object.DontDestroyOnLoad example.
//
// This script example manages the playing audio. The GameObject with the
// "music" tag is the BackgroundMusic GameObject. The AudioSource has the
// audio attached to the AudioClip.

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Fox");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            Debug.Log("Objeto lobo  HA sido destruido");
        }

        DontDestroyOnLoad(this.gameObject);
        Debug.Log("Objeto lobo NO  a sido destruido");
    }
}
