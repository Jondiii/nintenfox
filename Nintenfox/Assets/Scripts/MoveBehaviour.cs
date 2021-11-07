using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{

    private Rigidbody playerRigidbody;

    public float moveSpeed;
    public float rotateSpeed;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Move(-1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Rotate(-1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Rotate(1);
        }
    }

    private void Move(float value)
    {
        playerRigidbody.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime * value);
    }

    private void Rotate(float value)
    {
        Vector3 rotation = Vector3.up * rotateSpeed * value * Time.deltaTime;
        playerRigidbody.MoveRotation(Quaternion.Euler(transform.localRotation.eulerAngles + Vector3.up * rotateSpeed * value * Time.deltaTime));
    }

}