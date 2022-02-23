<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public Camera cam;

    Vector2 mousePos;

    public Vector2 angles;

    public float offset;

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + offset;

        if (gameObject.name.Contains("Left"))
        {
            if (angles.x < angle || angle < angles.y)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            else
            {
                var nearest = angles.x;
                var A = Mathf.Abs(Mathf.DeltaAngle(angle, angles.x));
                var B = Mathf.Abs(Mathf.DeltaAngle(angle, angles.y));
                if (A > B)
                {
                    nearest = angles.y;
                }
                transform.rotation = Quaternion.Euler(0f, 0f, nearest);
            }
        }
        else
        {
            if (angles.x < angle && angle < angles.y)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            else
            {
                var nearest = angles.x;
                var A = Mathf.Abs(Mathf.DeltaAngle(angle, angles.x));
                var B = Mathf.Abs(Mathf.DeltaAngle(angle, angles.y));
                if (A > B)
                {
                    nearest = angles.y;
                }
                transform.rotation = Quaternion.Euler(0f, 0f, nearest);
            }
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public Camera cam;

    Vector2 mousePos;

    public Vector2 angles;

    public float offset;

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + offset;

        if (gameObject.name.Contains("Left"))
        {
            if (angles.x < angle || angle < angles.y)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            else
            {
                var nearest = angles.x;
                var A = Mathf.Abs(Mathf.DeltaAngle(angle, angles.x));
                var B = Mathf.Abs(Mathf.DeltaAngle(angle, angles.y));
                if (A > B)
                {
                    nearest = angles.y;
                }
                transform.rotation = Quaternion.Euler(0f, 0f, nearest);
            }
        }
        else
        {
            if (angles.x < angle && angle < angles.y)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, angle);
            }
            else
            {
                var nearest = angles.x;
                var A = Mathf.Abs(Mathf.DeltaAngle(angle, angles.x));
                var B = Mathf.Abs(Mathf.DeltaAngle(angle, angles.y));
                if (A > B)
                {
                    nearest = angles.y;
                }
                transform.rotation = Quaternion.Euler(0f, 0f, nearest);
            }
        }
    }

    // No se como funcionan los angulos, pero se me ha ocurrido para mejorar la jugabilidad que, cuando el personaje este parado (no pulsando WASD) pueda apuntar a donde quiera. Para eso debe calcular el angulo al que esta apuntando, y si es entre 45º y 135º que mire a la derecha (y apunte con la linterna al raton), si es entre 135º y 225º a abajo, entre 225º y 315º a la izquierda y 315º y 45º a arriba
    // Esto lo haria comprobando las teclas que se estan tocando en el Update de PlayerMovement, y viniendo a una funcion auxiliar que calcule el angulo del raton para devolverle a que lado ha de girar al personaje. Creo que una vez girado, apuntar al raton deberia estar ya programado en el fixedupdate

/*
    public int dirDetector()
    {
        int resultDir;

        Vector2 lookDir = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        if (45 < angle && angle <= 135)
            resultDir = 0;
        else if (135 < angle && angle <= 225)
            resultDir = 1;
        else if (225 < angle && angle <= 315)
            resultDir = 2;
        else
            resultDir = 3;

        return resultDir;
    }
*/
}
>>>>>>> Stashed changes
