using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerStats stats = null;
    float playerSpeed, batteryTimer;
    int battery, originalBattery, nRecharges;
    bool lanternOn = true;
    bool lanternWasOn = false;

    public Animator animator;
    public Rigidbody2D rb;
    public BatteryBar batteryBar;

    Vector2 movement;

    public KeyCode up;      // Creo las variables vacias para poder modificarlas desde el menu de opciones. Por defecto las teclas de movimiento seran WASD
    public KeyCode left;
    public KeyCode down;
    public KeyCode right;
    public KeyCode run;
    public KeyCode light;

    float lastDirection = 0.0f;

    public Camera cam;
    Vector2 lookDir, mousePos;
    float angle;

    public List<GameObject> luces = new List<GameObject>();

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        playerSpeed = stats.GetSpeed();     // Cogemos la velocidad del script PlayerStats
        battery = stats.GetBattery();       // Cogemos la bateria del script PlayerStats
        originalBattery = battery;      // Guardo cuanto es la bateria originalmente para despues recargarla si se puede
        batteryBar.SetInitialBattery();

        up = KeyCode.W;     // Cuando avancemos en el juego, lo mas probable es que quitemos esto de aqui y lo pongamos en alguna otra funcion, para que al cambiar los controles desde opciones
        left = KeyCode.A;   // no se reseteen cada vez que entremos en la escena o algo asi
        down = KeyCode.S;
        right = KeyCode.D;
        run = KeyCode.LeftShift;
        light = KeyCode.Mouse0;
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

        if ((movement.x == 0) && (movement.y == 0))
        {
            FreeLooking();
        }


        // Programamos un sprint si se mantiene pulsado el boton del shift derecha
        if (Input.GetKey(run)){             // Si se usa el sprint, la linterna se apaga automaticamente
            playerSpeed = stats.GetSprint();
            if (lanternOn)
                lanternWasOn = true;
            Debug.Log("Linterna apagada");
            lanternOn = false;
        }
        else
        {
            playerSpeed = stats.GetSpeed();
            if (lanternWasOn)
            {
                Debug.Log("Linterna endendida");
                lanternOn = true;
                lanternWasOn = false;
            }
        }

        if (Input.GetKeyDown(light)){       // Si se pulsa el boton de la linterna
            battery = stats.GetBattery();       // Actualizo la variable battery

            if (!lanternOn && battery!=0)       // Si estaba apagada y queda bateria, encenderla
            {
                Debug.Log("Linterna endendida");
                lanternOn = true;
            }
            else                                // Si estaba encendida, apagarla
            {
                Debug.Log("Linterna apagada");
                lanternOn = false;
            }
        }

        BatteryFunction();      // Funcion que hace que baje la bateria poco a poco

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("LastDirection", lastDirection);

        if (lanternOn)
        {
            foreach(var luz in luces)
                luz.SetActive(true);
        }
        else
        {
            foreach(var luz in luces)
                luz.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.deltaTime);
    }

    void FreeLooking()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        lookDir = mousePos - (Vector2)transform.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        // Debug.Log("angulo: " + angle);

        if (-45 < angle && angle <= 45)         // derecha
            lastDirection = 2.0f;
        else if (45 < angle && angle <= 135)    // arriba
            lastDirection = 1.0f;
        else if (135 < angle || angle <= -135)   // izquierda
            lastDirection = 3.0f;
        else                                    // abajo
            lastDirection = 0.0f;
    }

    void BatteryFunction()
    {
        if (lanternOn)
        {
            batteryTimer += Time.deltaTime;     // Timer que calcula cuanto le queda para que la bateria pierda una rayita
            battery = stats.GetBattery();       // Actualizo la variable battery

            if (batteryTimer >= 10.0f){
                batteryTimer = 0.0f;
                battery--;
                stats.SetBattery(battery);      // Actualizo la variable battery tras reducirla
                batteryBar.SetBattery(battery);
            }

            if (battery == 0)       // Si te quedas sin rayitas en la bateria (la bateria actual se agota)
            {
                nRecharges = stats.GetRecharges();      // Cogemos la bateria del script PlayerStats

                if (nRecharges > 0)     // Si quedan recargas, la usamos (y perdemos una)
                {
                    stats.SetBattery(originalBattery);
                    batteryBar.SetBattery(originalBattery);     // Actualizo la variable battery tras recuperar su tamanio original
                    nRecharges--;
                    stats.SetRecharges(nRecharges);   // Guardamos la variable restandole la usada
                }
                else        // Si no, logicamente la luz se apaga
                {
                    Debug.Log("Linterna apagada");
                    lanternOn = false;
                }
            }
        }
        else        // Caso en el que te quedas sin bateria, pero justo coges una carga y la recuperas
        {
            battery = stats.GetBattery();       // Actualizo la variable battery
            nRecharges = stats.GetRecharges();      // Cogemos la bateria del script PlayerStats

            if (nRecharges > 0 && battery == 0)
            {
                stats.SetBattery(originalBattery);
                batteryBar.SetBattery(originalBattery);     // Actualizo la variable battery tras recuperar su tamanio original
                nRecharges--;
                stats.SetRecharges(nRecharges);   // Guardamos la variable restandole la usada
                Debug.Log("Linterna encendida");
                //lanternOn = true;
            }
        }
        //Debug.Log("La literna esta encencida: " + lanternOn);
        //Debug.Log("batteryTimer: " + batteryTimer);
        //Debug.Log("Current battery: " + battery);
    }
}
