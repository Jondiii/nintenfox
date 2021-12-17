using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiradorPortal : MonoBehaviour
{
    public Transform zorro;
    private bool mira = false;

    void Update()
    {
        if (mira == true)
        {
            transform.LookAt(zorro);
            transform.localRotation = Quaternion.Euler(-90f, transform.localRotation.eulerAngles.y, 0f);
            mira = false;
        }

    }

    public void looker()
    {
        Debug.Log("patatap");
        mira = true;
    }
}
