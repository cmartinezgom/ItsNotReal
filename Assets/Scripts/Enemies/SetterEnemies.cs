using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

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

    [SerializeField] private TeleportPlayer tp;
    [SerializeField] private GameObject globalLight;
    [SerializeField] private float lightLvl;

    public Transform keyDrop;

    public bool roundStarted = true;

    public bool miniBoss = false;
    public bool finalBoss = false;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && roundStarted)
        {
            if (!miniBoss && !finalBoss)
            {
                FindObjectOfType<AudioManager>().Transition("Hall", "Round");
            }else if (miniBoss)
            {
                FindObjectOfType<AudioManager>().Transition("Hall", "Opening Boss");
                StartCoroutine(PlayBossMusic("Boss Fight"));
            }
            else
            {
                FindObjectOfType<AudioManager>().Transition("Hall", "Opening Boss");
                StartCoroutine(PlayBossMusic("Final Boss"));
            }

            PlayerStats stats = col.gameObject.GetComponent<PlayerStats>();
            stats.SetIsRunningDown(true);

            spawnStats.SetEnemyList(enemies);
            spawnStats.SetEnemyProbs(enemyProbs);
            spawnStats.SetEnemyCounter(enemyCounter);
            spawnStats.SetSpawnDistance(spawnDistance);
            spawnStats.SetMinEnemyCooldown(minEnemyCooldown);
            spawnStats.SetMaxEnemyCooldown(maxEnemyCooldown);
            spawnStats.SetRoundStarted(roundStarted);
            spawnStats.SetTp(tp);
            spawnStats.SetRoom(gameObject);
            spawnStats.SetKeyDrop(keyDrop);
            spawnStats.spawnedKey = false;
            spawnStats.miniBoss = miniBoss;
            roundStarted = false;

            var light = globalLight.GetComponent<Light2D>();
            light.intensity = lightLvl;     // Oscurecemos la sala como queramos
        }
    }

    IEnumerator PlayBossMusic(string name)
    {
        yield return new WaitForSeconds(7f);
        FindObjectOfType<AudioManager>().Play(name);
    }
}
