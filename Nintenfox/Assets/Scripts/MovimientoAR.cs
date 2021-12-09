using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAR:MonoBehaviour
{
    private int prov;
    private bool inMove = false;
    private bool busy = false;
    private Animator animController;
    private string tipo = "stop";

    public float moveSpeed;
    public Transform target;
    public Vector3 velocity = Vector3.zero;
    public Transform shop;
    public Transform food;
    public Transform food2;



    // Update is called once per frame
    void Awake()
    {
        animController = GetComponent<Animator>();
        InvokeRepeating("movementChooser", 1, 2);
        
    }

    void Update()
    {
        switch (tipo)
        {
            case "random":
                animController.SetBool("Moving", true);
                transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, moveSpeed * Time.deltaTime);
                transform.LookAt(target);
                transform.localRotation = Quaternion.Euler(0f, transform.localRotation.eulerAngles.y, 0f);

                // Debug.Log(Vector3.Distance(transform.position, target.position));
                if (0.2f > Vector3.Distance(transform.position, target.position))
                {
                    tipo = "stop";
                    animController.SetBool("Moving", false);
                }
            break;

            case "tienda":
                animController.SetBool("Moving", true);
                transform.position = Vector3.SmoothDamp(transform.position, shop.position, ref velocity, moveSpeed * Time.deltaTime);
                transform.LookAt(shop);
                transform.localRotation = Quaternion.Euler(0f, transform.localRotation.eulerAngles.y, 0f);
               
                if (0.2f > Vector3.Distance(transform.position, shop.position))
                {
                    tipo = "stop";
                    animController.SetBool("Moving", false);
                }

            break;
            case "comida":
                //cambiar esto
                animController.SetBool("Moving", true);
                transform.position = Vector3.SmoothDamp(transform.position, food.position, ref velocity, moveSpeed * Time.deltaTime);
                transform.LookAt(food);
                transform.localRotation = Quaternion.Euler(0f, transform.localRotation.eulerAngles.y, 0f);
                transform.LookAt(food2);
                if (0.2f > Vector3.Distance(transform.position, food.position))
                {
                    tipo = "stop";
                    //animController.SetBool("Moving", false);
                    Debug.Log("HE LLEGADO AL OBJETIVO");
                    //animController.SetBool("Eating", true);
                 
                }

                break;
        }
        
        
    }

    void movementChooser() 
    {
        if (tipo == "stop")
        {
            prov = Random.Range(0 , 100);
            Debug.Log("prov:" + prov);
        
            if (prov > 80)
            {
                Debug.Log("Entro");
                
                target.localPosition = new Vector3(Random.Range(-2f, 2f),0 , Random.Range(-2f, 2f));
                Debug.Log(target.position);
                transform.LookAt(target);
                tipo = "random";
            }
        }
    }

    public void goToCard()
    {
        tipo = "tienda";
    }

    public void goToCard2()
    {
        tipo = "comida";
    }

}
