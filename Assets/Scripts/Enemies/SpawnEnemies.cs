using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public List<int> enemyProbs = new List<int>();
    public int enemyCounter;       // Para las pruebas 8 enemigos esta bien, pero mas adelante habra que crear una lista con todas las habitaciones, y coger el numero que le corresponda a cada una
    public float spawnDistance;     // Distancia a la que spawnean los enemigos. Lo importante es que no se vea en pantalla
    public float minEnemyCooldown, maxEnemyCooldown;     // Cooldown min y max con el que spawnean
    public bool roundStarted = false;

    float angle, xPos, yPos;
    int enemyProbability, probsCounter, loopCounter;

    GameObject room;

    void Update()
    {
        if (roundStarted)
        {
            roundStarted = false;
            StartCoroutine(EnemyAppears());
        }
    }

    IEnumerator EnemyAppears()
    {
        yield return new WaitForSeconds(2);     // Esperamos un par de segundos para empezar la ronda

        while (enemyCounter > 0)
        {
            angle = Random.Range(0,360);        // Se randomiza el angulo en el que apareceran
            xPos = (Mathf.Sin(angle) * spawnDistance) + transform.position.x;       // Calculamos el seno y el coseno del angulo, pues lo conocemos ademas de la hipotenusa del triangulo (spawnDistance)
            yPos = (Mathf.Cos(angle) * spawnDistance) + transform.position.y;       // Con estos datos podemos saber la posicion en la que tiene que spawnear para que este a la distancia (radio de la circunferencia) que queremos

            enemyProbability = Random.Range(0,100);        // Se randomiza el enemigo que aparecera
            
            foreach (int enemyNumber in enemyProbs)
            {
                if (enemyNumber > enemyProbability)
                {
                    Instantiate (enemies[loopCounter], new Vector2(xPos, yPos), Quaternion.identity);
                }
                else
                {
                    probsCounter += enemyNumber;
                    loopCounter++;
                }
            }

            enemyCounter--;

            yield return new WaitForSeconds(Random.Range(minEnemyCooldown,maxEnemyCooldown));     // Esperamos el cooldown para spawnear al siguiente enemigo
        }

        Destroy(room);
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

    public void SetRoom(GameObject room)
    {
        this.room = room;
    }

    #endregion
}
