using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour
{

    private Rigidbody playerRigidbody;

    public float moveSpeed;
    public float rotateSpeed;
    private Animator foxAnimator;

    public float jumpForce;
    private int groundCollisions;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        foxAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!Input.anyKey)
        {
            foxAnimator.Play("Fox_Run_InPlace");
        }

        if (Input.GetKey(KeyCode.A))
        {
            foxAnimator.Play("Fox_Run_Left_InPlace");
            MoveSideways(-1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            foxAnimator.Play("Fox_Run_Right_InPlace");
            MoveSideways(1);
        }

        if (Input.GetKey(KeyCode.PageUp))
        {
            Move(1);
        }

        if (Input.GetKey(KeyCode.PageDown))
        {
            Move(-1);
        }

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Rotate(-1);
        }

        if (Input.GetKey(KeyCode.RightAlt))
        {
            Rotate(1);
        }

        bool isGrounded = groundCollisions > 0;

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            foxAnimator.Play("Fox_Jump");
            Vector3 jumpVector = Vector3.up * jumpForce;
            playerRigidbody.AddForce(jumpVector);
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

    private void MoveSideways(float value)
    {
        playerRigidbody.MovePosition(transform.position + transform.right * moveSpeed * Time.deltaTime * value);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            groundCollisions++;
        }

        if (collision.gameObject.tag == "Finish")
        {
            GroundGenerator.instance.gameOver = true;
        }
        
        if (collision.gameObject.tag == "Coin")
        {
            GroundGenerator.instance.score += 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            groundCollisions--;
        }
    }


}