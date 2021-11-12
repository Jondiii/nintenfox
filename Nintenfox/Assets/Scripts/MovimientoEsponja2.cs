using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEsponja2 : MonoBehaviour
{
    //Variable para gestionar la velocidad del movimiento
    public float speed;

    //Variable para establecer un punto de destino
    Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        //Inicialmente el punto de destino de la posicion actual
        target = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        //Detectamos cuando hacemos click izquierdo
        if (Input.GetMouseButton(0))
        {

            //Buscamos la posicion del clic respecto a la escena
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Establecemos la z a 0 para que no se modifique la profundidad
            target.z = 0;
        }

        //Movemos el objeto hacia el punto de destino a una velocidad rectificada
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //Opticamente podemos deb
    }
}
