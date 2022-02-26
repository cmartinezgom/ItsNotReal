using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetterEnemies : MonoBehaviour
{
    [Header("Spawn Stats")]
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();        // SerializeField para que sea visible desde el editor de Unity pese a ser una variable privada
    [SerializeField] private List<int> enemyProbs = new List<int>();
    [SerializeField] private int enemyCounter;
    [SerializeField] private float spawnDistance;
    [SerializeField] private float minEnemyCooldown;
    [SerializeField] private float maxEnemyCooldown;
    [SerializeField] private SpawnEnemies spawnStats;

    bool roundStarted = true;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            spawnStats.SetEnemyList(enemies);
            spawnStats.SetEnemyProbs(enemyProbs);
            spawnStats.SetEnemyCounter(enemyCounter);
            spawnStats.SetSpawnDistance(spawnDistance);
            spawnStats.SetMinEnemyCooldown(minEnemyCooldown);
            spawnStats.SetMaxEnemyCooldown(maxEnemyCooldown);
            spawnStats.SetRoundStarted(roundStarted);
            spawnStats.SetRoom(gameObject);
        }
    }
}
