using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{

    PlayerStats stats = null;
    //EnemyStats enemyStats = null;
    float fearCounter;
    float maxLvFear;
    float enemyDamage;
    float greaterDamage = 0f;

    public GameObject EventSystem;
    int visibleEnemies;
    //List<float> enemyDamageList = new List<float>();
    List<EnemyStats> enemyList = new List<EnemyStats>();
    List<EnemyStats> enemyListExploded = new List<EnemyStats>();

    void Start()
    {
        stats = gameObject.transform.parent.GetComponent<PlayerStats>();
        fearCounter = stats.GetLvFear();
        maxLvFear = stats.GetMaxLvFear();     // Cogemos el nivel de  inicial del script PlayerStats
        stats.SetMaxLvFear(maxLvFear);        // seteo el lof inicial
    }

    void Update()
    {

        if (enemyList.Count != 0)     // Funcion que aumenta el Level of Fear si tiene un fantasma en su rango de vision cercano
        {
            fearCounter = stats.GetLvFear();
            foreach (EnemyStats enemy in enemyList)
            {
                if (greaterDamage < enemy.GetDamage())
                {
                    greaterDamage = enemy.GetDamage();
                }

                if (Vector3.Distance(enemy.transform.position,transform.position) < 0.1f)
                {
                    fearCounter += enemy.GetDamage() * 10;      // De momento hace 10 veces el damage que hace normalmente
                    stats.SetLvFear(fearCounter);
                    enemyListExploded.Add(enemy);
                }
            }

            fearCounter += greaterDamage * Time.deltaTime;
            stats.SetLvFear(fearCounter);

            foreach (EnemyStats enemy in enemyListExploded)     // Esto es para evitar problemas de concurrencia con la lista
            {
                enemyList.Remove(enemy);
                enemy.Explode();
            }
            enemyListExploded.Clear();
        }

        if (fearCounter >= maxLvFear)      // Funcion que comprueba si el Level of Fear esta al maximo, y en tal caso pierde
        {
            EventSystem.GetComponent<SceneLoader>().GameOver();
        }

        greaterDamage = 0.0f;

    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            //enemyStats = col.GetComponent<EnemyStats>();
            //enemyDamage = enemyStats.GetDamage();       // Coge el damage del monstruo y lo incluye en la lista
            enemyList.Add(col.GetComponent<EnemyStats>());
            //visibleEnemies++;       // Aumenta en uno los mosntruos en nuestro rango de vision cercano
            /*
            if (enemyDamage > greaterDamage)        // Si el damage del nuevo monstruo es el mayor, es el que comienza a hacer danio
            {
                greaterDamage = enemyDamage;
            }
            */
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            //enemyStats = col.GetComponent<EnemyStats>();
            //enemyDamage = enemyStats.GetDamage();
            enemyList.Remove(col.GetComponent<EnemyStats>());        // Elimina el damage del mosntruo que sale de nuestro campo de vision cercano de la lista
            //visibleEnemies--;       // Decrementa en uno el num de monstruos en nuestro campo de vision cercano
/*
            if (enemyDamage == greaterDamage)       // En caso de que el damage del monstruo que se va fuese el mas alto, debe recorrer la lista para sustituirlo por el siguiente mas alto, pues este ya no esta
            {
                enemyDamage = 0f;       // reseteamos el damage, y recorremos la lista para quedarnos finalmente con el mayor
                foreach (float damage in enemyDamageList)
                {
                    if (damage > enemyDamage)
                        greaterDamage = damage;
                }
            }
            */
        }
    }
}
