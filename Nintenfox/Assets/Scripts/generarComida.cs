using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generarComida : MonoBehaviour
{
    public GameObject manzana;
    // Start is called before the first frame update
    public void generar()
    {
        if (transform.childCount == 0)
        {
            var manz = Instantiate(manzana, new Vector3(0, 0, 0), Quaternion.identity);
            manz.transform.parent = transform;
            manz.transform.localPosition = new Vector3(0, 0.15f, 0);
        }
        
    }
}
