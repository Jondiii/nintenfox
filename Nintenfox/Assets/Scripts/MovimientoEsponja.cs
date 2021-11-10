using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEsponja : MonoBehaviour
{
    private Vector3 targetPosition;

    private Quaternion targetRotation;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //este 1 me llo desplaza tantas veces como hay en el siguiente codigo
            bool didHit = Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, 1 << LayerMask.NameToLayer("MovementClean"));

            //La esponja se mueve al punto donde se a clicado con el raton
            if (didHit)
            {
                MoveTo(hit.point);
            }
        }

        UpdatePosition();
        UpdateRotation();
    }

    private void MoveTo(Vector3 to)
    {
        //la posicion a la que queremos ir - la posicion en la que estamos
        Vector3 directionVector = to - transform.position;

        directionVector = transform.parent.InverseTransformDirection(directionVector);

        //comprueba que estemos tratando de mover la esponja a mas de 0.5cm, sino no se mueve
        if (directionVector.magnitude < .05f)
        {
            return;
        }

        //esto nos devuelve una direccion hacia la que se va a mover la esponja
        var newRotation = Quaternion.LookRotation(directionVector);

        //se lo aplicamos al helicoptero y entonces antes de moverse la esponja va a mirar hacia la direccion que se va a mover
        targetRotation = newRotation;
        targetPosition = transform.parent.InverseTransformPoint(to);
    }

    //para animar el movimiento de la esponja
    private void UpdatePosition()
    {
        //para hacer interpolaciones (posicion origen - destino)
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime);
    }

    //para animar la rotacion de la esponja
    private void UpdateRotation()
    {
        //para hacer interpolaciones (posicion origen - destino)
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime);
    }

    public void ResetPosition()
    {
        transform.localPosition = Vector3.zero;
        targetPosition = Vector3.zero;
    }
}
