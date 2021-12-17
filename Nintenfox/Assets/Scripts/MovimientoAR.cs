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
    public Transform portal;

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

            case "portal":
                animController.SetBool("Moving", true);

                transform.position = Vector3.SmoothDamp(transform.position, new Vector3(portal.position.x, 0, portal.position.z), ref velocity, moveSpeed * Time.deltaTime);
                transform.LookAt(portal);
                transform.localRotation = Quaternion.Euler(0f, transform.localRotation.eulerAngles.y, 0f);

                if (0.6f > Vector3.Distance(transform.position, portal.position))
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
                
                Debug.Log(Vector3.Distance(transform.position, food.position));
                if (2f > Vector3.Distance(transform.position, food.position))
                {
                    animController.SetBool("Moving", false);
                    animController.SetBool("Eating", true);
                    

                    if (0.2f > Vector3.Distance(transform.position, food.position))
                    {

                        
                        Debug.Log("HE LLEGADO AL OBJETIVO");
                        
                        tipo = "stop";
                        animController.SetBool("Eating", false);
                    }
                }

                break;
                
        }
        
        
    }

    void movementChooser() 
    {
        if (tipo == "stop")
        {
            prov = Random.Range(0 , 100);
            //Debug.Log("prov:" + prov);
        
            if (prov > 80)
            {
                Debug.Log("Entro");
                
                target.localPosition = new Vector3(Random.Range(-2f, 2f),0 , Random.Range(-2f, 2f));
                //Debug.Log(target.position);
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

    public void goToPortal()
    {
        tipo = "portal";
    }

}
