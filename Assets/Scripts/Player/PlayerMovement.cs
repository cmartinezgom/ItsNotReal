using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerStats stats = null;
    float playerSpeed;

    public Animator animator;
    public Rigidbody2D rb;

    Vector2 movement;

    public KeyCode up;      // Creo las variables vacias para poder modificarlas desde el menu de opciones. Por defecto las teclas de movimiento seran WASD
    public KeyCode left;
    public KeyCode down;
    public KeyCode right;
    public KeyCode run;

    float lastDirection = 0.0f;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        playerSpeed = stats.GetSpeed();     // Cogemos la velocidad del script PlayerStats

        up = KeyCode.W;     // Cuando avancemos en el juego, lo mas probable es que quitemos esto de aqui y lo pongamos en alguna otra funcion, para que al cambiar los controles desde opciones
        left = KeyCode.A;   // no se reseteen cada vez que entremos en la escena o algo asi
        down = KeyCode.S;
        right = KeyCode.D;
        run = KeyCode.LeftShift;
    }


    void Update()
    {
        // Los siguientes ifs marcan el movimiento en el eje de la X o de la Y dependiendo de la tecla pulsada. La velocidad de movimiento se puede modificar desde la funcion PlayerStats
        if (Input.GetKey(up))
        {
            movement.y = 1f;
            lastDirection = 1.0f;
        }
        else if (Input.GetKey(down))
        {
            movement.y = -1f;
            lastDirection = 0.0f;
        }
        else
        {
            movement.y = 0f;
        }

        if (Input.GetKey(left))
        {
            movement.x = -1f;
            lastDirection = 3.0f;
        }
        else if (Input.GetKey(right))
        {
            movement.x = 1f;
            lastDirection = 2.0f;
        }
        else
        {
            movement.x = 0f;
        }

        // Programamos un sprint si se mantiene pulsado el botón del espacio
        if (Input.GetKey(run)){
            playerSpeed = stats.GetSprint();
        }
        else
        {
            playerSpeed = stats.GetSpeed();
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("LastDirection", lastDirection);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.deltaTime);
    }
}
