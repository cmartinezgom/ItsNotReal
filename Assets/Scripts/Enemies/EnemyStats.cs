using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Chase,

    Retreat,

    Static,

    Ranged,

    Pasive
}

public class EnemyStats : MonoBehaviour
{
    [Header("Speed")]
    //Velocidad de movimiento
    [SerializeField] private float speed = 3.5f;
    //Velocidad de movimiento en caso de estar enfadado
    [SerializeField] private float agroSpeed = 3.5f;

    [Header("Health")]
    //Tiempo que hay que alumbrarle para que desaparezca
    [SerializeField] private float maxHealth = 2.0f;
    [SerializeField] private float health = 2.0f;

    [Header("Damage")]
    //Tiempo que hay que alumbrarle para que desaparezca
    [SerializeField] private float damage = 1.0f;
    //Distancia con respecto al jugador, ya sea para huir o para atacar
    [SerializeField] private float distance = 3.0f;

    [Header("Type")]
    //Tipo de enemigo
    [SerializeField] private EnemyType type;

    [Header("Particles")]
    [SerializeField] private GameObject killParticlesPrefab;
    [SerializeField] private GameObject explodeParticlesPrefab;

    [Header("Power-Up")]
    [SerializeField] private float percentPUps = 5.0f;       // Porcentaje del 5%
    [SerializeField] private List<GameObject> prefabsPUps = new List<GameObject>();

    #region GETTERS Y SETTERS
    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetAgroSpeed()
    {
        return agroSpeed;
    }

    public void SetAgroSpeed(float agroSpeed)
    {
        this.agroSpeed = agroSpeed;
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float health)
    {
        this.health = health;
    }
    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public float GetDamage()
    {
        return health;
    }

    public void SetDamage(float health)
    {
        this.health = health;
    }

    public float GetDistance()
    {
        return distance;
    }

    public void SetDistance(float distance)
    {
        this.distance = distance;
    }

    public EnemyType GetEnemyType()
    {
        return type;
    }

    public void SetEnemyType(EnemyType type)
    {
        this.type = type;
    }

    #endregion

    public void Damage(float damage)
    {
        health -= damage;

        if (health < 0)
        {
            health = 0;
        }

        if(health == 0) Kill();
    }

    public void Heal(float heal)
    {
        health += heal;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Kill()
    {
        var killParticles = Instantiate(killParticlesPrefab, transform.position, Quaternion.identity);
        killParticles.GetComponent<ParticleSystem>().Play();
        var rand = Random.Range(0f,100f);
        if (rand <= 5)     // porcentaje del 5% para testear, luego cambiarlo por la variable de arriba
        {
            Debug.Log("Pole");
            Instantiate(prefabsPUps[Random.Range(0,prefabsPUps.Count)], transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    public void Explode()
    {
        var explodeParticles = Instantiate(explodeParticlesPrefab, transform.position, Quaternion.identity);
        explodeParticles.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }
}
