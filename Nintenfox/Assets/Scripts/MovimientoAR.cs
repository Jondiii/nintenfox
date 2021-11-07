using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAR : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private int prov;
    private bool inMove = true;
    private Animator animController;

    public float moveSpeed;
    public Transform target;
    public Vector3 velocity = Vector3.zero;
    

    // Update is called once per frame
    void Awake()
    {
        animController = GetComponent<Animator>();
        InvokeRepeating("movementChooser", 1, 2);
    }
    
    void Update()
    {
        if (inMove == true) {
            animController.SetBool("Moving", true);
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, moveSpeed * Time.deltaTime);
            transform.LookAt(target);

            Debug.Log(Vector3.Distance(transform.position, target.position));
            if ( 2f > Vector3.Distance(transform.position, target.position))
            {
                inMove = false;
                animController.SetBool("Moving", false);
            }
        }
       
    }

    void movementChooser() 
    {
        if (inMove == false)
        {
            prov = Random.Range(0 , 100);
            Debug.Log("prov:" + prov);
        
            if (prov > 80)
            {
                Debug.Log("Entro");

                target.position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
                inMove = true;
            }
        }
    }
    
}
