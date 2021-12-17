using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirador : MonoBehaviour
{
    public Transform zorro;
    private bool mira = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mira == true)
        {
            transform.LookAt(zorro);
            transform.localRotation = Quaternion.Euler(-180f, transform.localRotation.eulerAngles.y, 0f);
            mira = false;
        }

    }

    public void looker()
    {
        mira = true;
        //transform.LookAt(zorro);
        //transform.localRotation = Quaternion.Euler(-180f, transform.localRotation.eulerAngles.y-180, 0f);
    }
}
