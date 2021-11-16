using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverConRaton : MonoBehaviour
{
    private Vector3 dondeClica;
    private float mZCoord;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        dondeClica = gameObject.transform.position - GetMoseWorldPos();
    }

    void OnMouseDrag()
    {

        transform.position = Input.mousePosition + dondeClica;
    }

    private Vector3 GetMoseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
