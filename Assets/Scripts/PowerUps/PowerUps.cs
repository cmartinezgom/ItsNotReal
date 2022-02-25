using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PowerUps : MonoBehaviour
{
    public GameObject pickUpEffect;

    [Header("Pilas")]
    //public float durationB = 4f;
    //public float multiplierB = 1.2f;

    [Header("Botas")]
    public float durationBot = 4f;
    public float multiplierBot = 1.2f;

    [Header("Reloj")]
    public float durationR = 4f;
    public float multiplierR = 0.8f;

    [Header("Piruleta")]
    public float amountP = 10.0f;

    [Header("Linterna")]
    public float amountL = 4.0f;

    [Header("Bombilla")]
    public float durationBomb = 4f;
    public float multiplierBomb = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.name.Contains("Pila"))
            {
                Pila(collision);
            } else if (gameObject.name.Contains("Botas"))
            {
                StartCoroutine(Botas(collision));
            }
            else if (gameObject.name.Contains("Reloj"))
            {
                StartCoroutine(Reloj());
            }
            else if (gameObject.name.Contains("Piruleta"))
            {
                Piruleta(collision);
            }
            else if (gameObject.name.Contains("Linterna"))
            {
                Linterna(collision);
            }
            else if (gameObject.name.Contains("Bombilla"))
            {
                StartCoroutine(Bombilla(collision));
            }
        }

    }

    void Pila(Collider2D player)
    {
        //Particulas
        Instantiate(pickUpEffect, transform.position, transform.rotation);

        //Aplicar efecto
        var stats = player.GetComponent<PlayerStats>();
        var nRecharges = stats.GetRecharges();

        if (nRecharges < 2)
        {
            nRecharges++;
            stats.SetRecharges(nRecharges);
        }
        else
        {
            stats.SetBattery(4);    // el valor maximo de la bateria
        }
        Debug.Log("Pila");

        //Deshabilitar PU
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponentInChildren<Light2D>().enabled = false;
        GetComponentInChildren<ParticleSystem>().Stop();

        //Wait
        //yield return new WaitForSeconds(duration);

        //Reverse effect
        //stats.SetSpeed(initialSpeed);

        //Quitar powerup
        Destroy(gameObject);
    }

    IEnumerator Botas(Collider2D player)
    {
        //Particulas
        Instantiate(pickUpEffect, transform.position, transform.rotation);

        //Aplicar efecto
        var stats = player.GetComponent<PlayerStats>();
        var initialSpeed = stats.GetSpeed();
        stats.SetSpeed(initialSpeed * multiplierBot);
        Debug.Log("Botas");

        //Deshabilitar PU
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponentInChildren<ParticleSystem>().Stop();
        GetComponentInChildren<Light2D>().enabled = false;

        //Wait
        yield return new WaitForSeconds(durationBot);

        //Reverse effect
        stats.SetSpeed(initialSpeed);

        //Quitar powerup
        Destroy(gameObject);
    }

    void Piruleta(Collider2D player)
    {
        //Particulas
        Instantiate(pickUpEffect, transform.position, transform.rotation);

        //Aplicar efecto
        var stats = player.GetComponent<PlayerStats>();
        var lvlOfFear = stats.GetLvFear();
        if (lvlOfFear > amountP)
        {
            lvlOfFear -= amountP;
        }
        else
        {
            lvlOfFear = 0;
        }
        stats.SetLvFear(lvlOfFear);
        Debug.Log("Piruleta");
        //stats.SetSpeed(initialSpeed * 2.0f);

        //Deshabilitar PU
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponentInChildren<ParticleSystem>().Stop();
        GetComponentInChildren<Light2D>().enabled = false;

        //Wait
        //yield return new WaitForSeconds(duration);

        //Reverse effect
        //stats.SetSpeed(initialSpeed);

        //Quitar powerup
        Destroy(gameObject);
    }

    void Linterna(Collider2D player)
    {
        //Particulas
        Instantiate(pickUpEffect, transform.position, transform.rotation);

        //Aplicar efecto
        //var stats = player.GetComponent<PlayerStats>();
        //var initialSpeed = stats.GetSpeed();
        Debug.Log("Linterna");
        //stats.SetSpeed(initialSpeed * 2.0f);

        //Deshabilitar PU
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponentInChildren<ParticleSystem>().Stop();
        GetComponentInChildren<Light2D>().enabled = false;

        //Wait
        //yield return new WaitForSeconds(durati);

        //Reverse effect
        //stats.SetSpeed(initialSpeed);

        //Quitar powerup
        Destroy(gameObject);
    }

    IEnumerator Reloj()
    {
        //Particulas
        Instantiate(pickUpEffect, transform.position, transform.rotation);

        //Aplicar efecto
        //var stats = player.GetComponent<PlayerStats>();
        //var initialSpeed = stats.GetSpeed();
        var fantasmas = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var fantasma in fantasmas)
        {
            var stats = fantasma.GetComponent<EnemyStats>();
            stats.SetSpeed(stats.GetSpeed() * multiplierR);
        }
        Debug.Log("Reloj");

        //stats.SetSpeed(initialSpeed * 2.0f);

        //Deshabilitar PU
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponentInChildren<ParticleSystem>().Stop();
        GetComponentInChildren<Light2D>().enabled = false;

        //Wait
        yield return new WaitForSeconds(durationR);

        //Reverse effect
        foreach (var fantasma in fantasmas)
        {
            if (fantasma!= null)
            {
                var stats = fantasma.GetComponent<EnemyStats>();
                stats.SetSpeed(stats.GetSpeed() / multiplierR);
            }
        }

        //Quitar powerup
        Destroy(gameObject);
    }

    IEnumerator Bombilla(Collider2D player)
    {
        //Particulas
        Instantiate(pickUpEffect, transform.position, transform.rotation);

        //Aplicar efecto
        //var stats = player.GetComponent<PlayerStats>();
        //var initialSpeed = stats.GetSpeed();
        //stats.SetSpeed(initialSpeed * multiplierBot);
        Debug.Log("Bombilla");

        //Deshabilitar PU
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponentInChildren<ParticleSystem>().Stop();
        GetComponentInChildren<Light2D>().enabled = false;

        //Wait
        yield return new WaitForSeconds(durationBomb);

        //Reverse effect
        //stats.SetSpeed(initialSpeed);

        //Quitar powerup
        Destroy(gameObject);
    }
}