using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiradorComida : MonoBehaviour
{
    public GameObject manzana;
    public GameObject jamon;
    public GameObject hamburguesa;


    private bool spining = false;
    private Vector3 manzanaTemp;
    private Vector3 jamonTemp;
    private Vector3 hamburguesaTemp;
    private string direction;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spining == true)
        {
            
            if (direction == "L")
            {
                //Debug.Log("update");

                manzana.transform.position = Vector3.Lerp(manzana.transform.position, jamonTemp,  moveSpeed * Time.deltaTime);

                jamon.transform.position = Vector3.Lerp(jamon.transform.position, hamburguesaTemp, moveSpeed * Time.deltaTime);

                hamburguesa.transform.position = Vector3.Lerp(hamburguesa.transform.position, manzanaTemp,  moveSpeed * Time.deltaTime);
                //Debug.Log(Vector3.Distance(manzana.transform.position, jamonTemp));
                if (0.01f > Vector3.Distance(manzana.transform.position, jamonTemp))
                {
                    
                    spining = false;
                }


            }
            else if (direction == "R")
            {
                manzana.transform.position = Vector3.Lerp(manzana.transform.position, hamburguesaTemp, moveSpeed * Time.deltaTime);

                jamon.transform.position = Vector3.Lerp(jamon.transform.position, manzanaTemp, moveSpeed * Time.deltaTime);

                hamburguesa.transform.position = Vector3.Lerp(hamburguesa.transform.position, jamonTemp, moveSpeed * Time.deltaTime);
                
                //Debug.Log(Vector3.Distance(manzana.transform.position, hamburguesaTemp));
                if (0.01f > Vector3.Distance(manzana.transform.position, hamburguesaTemp))
                {
                    spining = false;
                }

            } 
        } 
    }

    public void spinR()
    {
        
        direction = "R";
        if (spining == false)
        {
            manzanaTemp = new Vector3(0,0,0) + manzana.transform.position;
           
            jamonTemp = new Vector3(0, 0, 0) + jamon.transform.position;
            
            hamburguesaTemp = new Vector3(0, 0, 0) + hamburguesa.transform.position;
           
            spining = true;       
        }
    }

    public void spinL()
    {
        
        direction = "L";
        if (spining == false)
        {
            manzanaTemp = new Vector3(0, 0, 0) + manzana.transform.position;

            jamonTemp = new Vector3(0, 0, 0) + jamon.transform.position;

            hamburguesaTemp = new Vector3(0, 0, 0) + hamburguesa.transform.position;

            spining = true;
        }
    }

}
