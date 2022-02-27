using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public List<int> enemyProbs = new List<int>();
    public int enemyCounter;       // Para las pruebas 8 enemigos esta bien, pero mas adelante habra que crear una lista con todas las habitaciones, y coger el numero que le corresponda a cada una
    public float spawnDistance;     // Distancia a la que spawnean los enemigos. Lo importante es que no se vea en pantalla
    public float minEnemyCooldown, maxEnemyCooldown;     // Cooldown min y max con el que spawnean
    bool roundStarted = false, roundFinished = false, roundFlag = true;
    public GameObject globalLight;

    float angle, xPos, yPos;
    int enemyProbability, probsCounter, loopCounter = 0;

    TeleportPlayer tp  = null;
    GameObject room;

    Transform keyDrop;
    public GameObject keyPrefab;
    public bool spawnedKey = false;

    public bool miniBoss = false;


    void Update()
    {
        StartCoroutine(EnemyAppears());
    }

    IEnumerator EnemyAppears()
    {
        if (roundStarted)
        {
            tp.blocked = true;
            roundStarted = false;
            yield return new WaitForSeconds(2);     // Esperamos un par de segundos para empezar la ronda

            while (enemyCounter > 0)
            {
                angle = Random.Range(0,360);        // Se randomiza el angulo en el que apareceran
                xPos = (Mathf.Sin(angle) * spawnDistance) + transform.position.x;       // Calculamos el seno y el coseno del angulo, pues lo conocemos ademas de la hipotenusa del triangulo (spawnDistance)
                yPos = (Mathf.Cos(angle) * spawnDistance) + transform.position.y;       // Con estos datos podemos saber la posicion en la que tiene que spawnear para que este a la distancia (radio de la circunferencia) que queremos

                enemyProbability = Random.Range(0, 100);        // Se randomiza el enemigo que aparecera
                probsCounter = 0;
                loopCounter = 0;
                foreach (int enemyNumber in enemyProbs)
                {
                    probsCounter += enemyNumber;

                    if (probsCounter > enemyProbability)
                    {
                        Instantiate (enemies[loopCounter], new Vector2(xPos, yPos), Quaternion.identity);
                        break;
                    }
                    else
                    {
                        loopCounter++;
                    }
                }

                enemyCounter--;

                if (enemyCounter == 0)
                {
                    roundFinished = true;
                }

                yield return new WaitForSeconds(Random.Range(minEnemyCooldown,maxEnemyCooldown));     // Esperamos el cooldown para spawnear al siguiente enemigo
            }

        }

        // Coger la llave para desbloquearlo

        if (enemyCounter == 0 && GameObject.FindGameObjectWithTag("Enemy") == null && roundFinished)
        {
            if (!spawnedKey)
            {
                Instantiate(keyPrefab, keyDrop.position, Quaternion.identity);
                spawnedKey = true;
                FindObjectOfType<AudioManager>().Play("KeySpawn");
            }
            yield return new WaitForSeconds(1f);
            FindObjectOfType<AudioManager>().Play("Door");
            roundFinished = false;
            StartCoroutine(GlowFade());
            PlayerStats stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            stats.SetIsRunningDown(false);
            if (miniBoss)
            {
                FindObjectOfType<AudioManager>().Transition("Boss Fight", "Hall");
            }
            else
            {
                FindObjectOfType<AudioManager>().Transition("Round", "Hall");
            }
            if (tp != null)     // Para evitar que explote el compilador
            {
                tp.Unlock();
            }
            Destroy(room);
        }
    }

    IEnumerator GlowFade()
    {
        var light = globalLight.GetComponent<Light2D>();

        for (float ft = light.intensity; ft <= 0.9; ft += 0.05f)        // Elegir que nivel de luz tendra el lobby principal
        {
            light.intensity = ft;
            yield return new WaitForSeconds(.1f);
        }
    }

    // Declaro los GETs y los SETs para que las variables sean accesibles desde otras funciones
    #region GETTERS Y SETTERS
    
    public void SetEnemyList(List<GameObject> enemies)
    {
        this.enemies = enemies;
    }
    public void SetEnemyProbs(List<int> enemyProbs)
    {
        this.enemyProbs = enemyProbs;
    }
    public void SetEnemyCounter(int enemyCounter)
    {
        this.enemyCounter = enemyCounter;
    }
    public void SetSpawnDistance(float spawnDistance)
    {
        this.spawnDistance = spawnDistance;
    }
    public void SetMinEnemyCooldown(float minEnemyCooldown)
    {
        this.minEnemyCooldown = minEnemyCooldown;
    }
    public void SetMaxEnemyCooldown(float maxEnemyCooldown)
    {
        this.maxEnemyCooldown = maxEnemyCooldown;
    }
    public void SetRoundStarted(bool roundStarted)
    {
        this.roundStarted = roundStarted;
    }

    public void SetTp(TeleportPlayer tp)
    {
        this.tp = tp;
    }
    public void SetRoom(GameObject room)
    {
        this.room = room;
    }

    public void SetKeyDrop(Transform keyDrop)
    {
        this.keyDrop = keyDrop;
    }

    #endregion
}
