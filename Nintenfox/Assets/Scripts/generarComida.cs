using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarComida : MonoBehaviour
{
    public GameObject manzana;

    public void generar()
    {
        if (transform.childCount == 0)
        {
            var manz = Instantiate(manzana, new Vector3(0, 0, 0), Quaternion.identity);
            manz.transform.parent = transform;
            manz.transform.localPosition = new Vector3(0, 0.15f, 0);
        }
        else
        {
            transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        }
        
    }

    public void loss()
    {
        transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
    }
  

}
