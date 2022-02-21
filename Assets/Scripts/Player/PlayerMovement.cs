using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerStats stats = null;
    float playerSpeed;

    public KeyCode up;      // Creo las variables vacias para poder modificarlas desde el menu de opciones. Por defecto las teclas de movimiento seran WASD
    public KeyCode left;
    public KeyCode down;
    public KeyCode right;
    public KeyCode space;


    void Start()
    {
        stats = GetComponent<PlayerStats>();
        playerSpeed = stats.GetSpeed();     // Cogemos la velocidad del script PlayerStats

        up = KeyCode.W;     // Cuando avancemos en el juego, lo mas probable es que quitemos esto de aqui y lo pongamos en alguna otra funcion, para que al cambiar los controles desde opciones
        left = KeyCode.A;   // no se reseteen cada vez que entremos en la escena o algo asi
        down = KeyCode.S;
        right = KeyCode.D;
        space = KeyCode.Space;
    }


    void Update()
    {
        // Los siguientes ifs marcan el movimiento en el eje de la X o de la Y dependiendo de la tecla pulsada. La velocidad de movimiento se puede modificar desde la funcion PlayerStats
        if (Input.GetKey(up))
        {
            gameObject.transform.Translate(0 , playerSpeed*Time.deltaTime , 0);
        }

        if (Input.GetKey(left))
        {
            gameObject.transform.Translate(-playerSpeed*Time.deltaTime , 0 , 0);
        }

        if (Input.GetKey(down))
        {
            gameObject.transform.Translate(0 , -playerSpeed*Time.deltaTime , 0);
        }

        if (Input.GetKey(right))
        {
            gameObject.transform.Translate(playerSpeed*Time.deltaTime , 0 , 0);
        }

        // Programamos un sprint si se mantiene pulsado el botón del espacio
        if (Input.GetKey(space)){
            playerSpeed = stats.GetSprint();
        }
        else
        {
            playerSpeed = stats.GetSpeed();
        }
    }
}
