<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{    
    public List<GameObject> enemies = new List<GameObject>();
    int enemyCounter = 8;       // Para las pruebas 8 enemigos esta bien, pero mas adelante habra que crear una lista con todas las habitaciones, y coger el numero que le corresponda a cada una
    float spawnDistance = 7.5f;     // Distancia a la que spawnean los enemigos. Lo importante es que no se vea en pantalla
    float enemyCooldown = 5.0f;     // Cooldown con el que spawnean, aunque mas adelante se puede cambiar por una cantidad de tiempo aleatoria para que la gente no coja el timing
    float angle, xPos, yPos;

    void Start()
    {
        StartCoroutine(EnemyAppears());
    }

    IEnumerator EnemyAppears()
    {
        while (enemyCounter > 0)
        {
            angle = Random.Range(0,360);        // Se randomiza el angulo en el que apareceran
            xPos = (Mathf.Sin(angle) * spawnDistance) + transform.position.x;       // Calculamos el seno y el coseno del angulo, pues lo conocemos ademas de la hipotenusa del triangulo (spawnDistance)
            yPos = (Mathf.Cos(angle) * spawnDistance) + transform.position.y;       // Con estos datos podemos saber la posicion en la que tiene que spawnear para que este a la distancia (radio de la circunferencia) que queremos

            Instantiate (enemies[0], new Vector2(xPos, yPos), Quaternion.identity);
            enemyCounter--;

            yield return new WaitForSeconds(enemyCooldown);     // Esperamos el cooldown para spawnear al siguiente enemigo
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{    
    public List<GameObject> enemies = new List<GameObject>();
    int enemyCounter = 8;       // Para las pruebas 8 enemigos esta bien, pero mas adelante habra que crear una lista con todas las habitaciones, y coger el numero que le corresponda a cada una
    float spawnDistance = 9.0f;     // Distancia a la que spawnean los enemigos. Lo importante es que no se vea en pantalla
    float enemyCooldown = 5.0f;     // Cooldown con el que spawnean, aunque mas adelante se puede cambiar por una cantidad de tiempo aleatoria para que la gente no coja el timing
    float angle, xPos, yPos;

    void Start()
    {
        StartCoroutine(EnemyAppears());
    }

    IEnumerator EnemyAppears()
    {
        while (enemyCounter > 0)
        {
            angle = Random.Range(0,360);        // Se randomiza el angulo en el que apareceran
            xPos = (Mathf.Sin(angle) * spawnDistance) + transform.position.x;       // Calculamos el seno y el coseno del angulo, pues lo conocemos ademas de la hipotenusa del triangulo (spawnDistance)
            yPos = (Mathf.Cos(angle) * spawnDistance) + transform.position.y;       // Con estos datos podemos saber la posicion en la que tiene que spawnear para que este a la distancia (radio de la circunferencia) que queremos

            Instantiate (enemies[0], new Vector2(xPos, yPos), Quaternion.identity);
            enemyCounter--;

            yield return new WaitForSeconds(enemyCooldown);     // Esperamos el cooldown para spawnear al siguiente enemigo
        }
    }
}
>>>>>>> Stashed changes
