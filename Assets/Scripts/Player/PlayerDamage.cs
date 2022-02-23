<<<<<<< Updated upstream
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{

    PlayerStats stats = null;
    EnemyStats enemyStats = null;
    float fearCounter;
    float lvFear;
    float enemyDamage;
    float greaterDamage = 0f;

    public GameObject EventSystem;
    public LevelOfFearBar lofBar;
    int visibleEnemies;
    List<float> enemyDamageList = new List<float>();

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        lvFear = stats.GetLvFear();     // Cogemos el nivel de miedo del script PlayerStats
        lofBar.SetInitialFear(lvFear);
    }

    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.E))        // De momento lo he puesto al pulsar una tecla para probar su funcionamiento, pero esto se debe cambiar a cuando reciba danio de un enemigo
        {
            fearCounter++;       // Tal y como lo he programado de momento, es una vida que decrece, pero imagino que deberia ser un contrario, como un contador de estres que al llegar a cierto punto colapse
            lofBar.SetFear(fearCounter);
        }
        */

        if (visibleEnemies > 0)     // Funcion que aumenta el Level of Fear si tiene un fantasma en su rango de vision cercano
        {
            fearCounter += greaterDamage * Time.deltaTime;
            lofBar.SetFear(fearCounter);
        }

        if (fearCounter >= lvFear)      // Funcion que comprueba si el Level of Fear esta al maximo, y en tal caso pierde
        {
            EventSystem.GetComponent<SceneLoader>().GameOver();
        }

    }

    void OnTriggerEnter2D (Collider2D col)
    {
        //Debug.Log("Entra!");        // Creo que hay un fallo, los enemigos entran 2 veces

        if (col.CompareTag("Enemy"))
        {
            enemyStats = col.GetComponent<EnemyStats>();
            enemyDamage = enemyStats.GetDamage();       // Coge el damage del monstruo y lo incluye en la lista
            enemyDamageList.Add(enemyDamage);
            visibleEnemies++;       // Aumenta en uno los mosntruos en nuestro rango de vision cercano

            if (enemyDamage > greaterDamage)        // Si el damage del nuevo monstruo es el mayor, es el que comienza a hacer danio
            {
                greaterDamage = enemyDamage;
            }
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        //Debug.Log("Sale!");     // Creo que hay un fallo, los enemigos salen 2 veces

        if (col.CompareTag("Enemy"))
        {
            enemyStats = col.GetComponent<EnemyStats>();
            enemyDamage = enemyStats.GetDamage();
            enemyDamageList.Remove(enemyDamage);        // Elimina el damage del mosntruo que sale de nuestro campo de vision cercano de la lista
            visibleEnemies--;       // Decrementa en uno el num de monstruos en nuestro campo de vision cercano

            if (enemyDamage == greaterDamage)       // En caso de que el damage del monstruo que se va fuese el mas alto, debe recorrer la lista para sustituirlo por el siguiente mas alto, pues este ya no esta
            {
                enemyDamage = 0f;       // reseteamos el damage, y recorremos la lista para quedarnos finalmente con el mayor
                foreach (float damage in enemyDamageList)
                {
                    if (damage > enemyDamage)
                        greaterDamage = damage;
                }
            }
        }
    }

}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{

    PlayerStats stats = null;
    EnemyStats enemyStats = null;
    float fearCounter;
    float lvFear;
    float enemyDamage;
    float greaterDamage = 0f;

    public GameObject EventSystem;
    public LevelOfFearBar lofBar;
    int visibleEnemies;
    List<float> enemyDamageList = new List<float>();

    void Start()
    {
        stats = gameObject.transform.parent.GetComponent<PlayerStats>();
        lvFear = stats.GetLvFear();     // Cogemos el nivel de miedo del script PlayerStats
        lofBar.SetInitialFear(lvFear);
    }

    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.E))        // De momento lo he puesto al pulsar una tecla para probar su funcionamiento, pero esto se debe cambiar a cuando reciba danio de un enemigo
        {
            fearCounter++;       // Tal y como lo he programado de momento, es una vida que decrece, pero imagino que deberia ser un contrario, como un contador de estres que al llegar a cierto punto colapse
            lofBar.SetFear(fearCounter);
        }
        */

        if (visibleEnemies > 0)     // Funcion que aumenta el Level of Fear si tiene un fantasma en su rango de vision cercano
        {
            fearCounter += greaterDamage * Time.deltaTime;
            lofBar.SetFear(fearCounter);
        }

        if (fearCounter >= lvFear)      // Funcion que comprueba si el Level of Fear esta al maximo, y en tal caso pierde
        {
            EventSystem.GetComponent<SceneLoader>().GameOver();
        }

    }

    void OnTriggerEnter2D (Collider2D col)
    {
        Debug.Log("Entra!");        // Creo que hay un fallo, los enemigos entran 2 veces

        if (col.CompareTag("Enemy") && CompareTag("Player"))
        {
            enemyStats = col.GetComponent<EnemyStats>();
            enemyDamage = enemyStats.GetDamage();       // Coge el damage del monstruo y lo incluye en la lista
            enemyDamageList.Add(enemyDamage);
            visibleEnemies++;       // Aumenta en uno los mosntruos en nuestro rango de vision cercano

            if (enemyDamage > greaterDamage)        // Si el damage del nuevo monstruo es el mayor, es el que comienza a hacer danio
            {
                greaterDamage = enemyDamage;
            }
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        Debug.Log("Sale!");     // Creo que hay un fallo, los enemigos salen 2 veces

        if (col.CompareTag("Enemy"))
        {
            enemyStats = col.GetComponent<EnemyStats>();
            enemyDamage = enemyStats.GetDamage();
            enemyDamageList.Remove(enemyDamage);        // Elimina el damage del mosntruo que sale de nuestro campo de vision cercano de la lista
            visibleEnemies--;       // Decrementa en uno el num de monstruos en nuestro campo de vision cercano

            if (enemyDamage == greaterDamage)       // En caso de que el damage del monstruo que se va fuese el mas alto, debe recorrer la lista para sustituirlo por el siguiente mas alto, pues este ya no esta
            {
                enemyDamage = 0f;       // reseteamos el damage, y recorremos la lista para quedarnos finalmente con el mayor
                foreach (float damage in enemyDamageList)
                {
                    if (damage > enemyDamage)
                        greaterDamage = damage;
                }
            }
        }
    }

}
>>>>>>> Stashed changes
