using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilDamage : MonoBehaviour
{
    public GameObject hitEffect;
    PlayerStats stats;
    float fearCounter;
    public float damage = 50f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Damage");
            stats = collision.gameObject.GetComponent<PlayerStats>();
            fearCounter = stats.GetLvFear();
            fearCounter += damage;      // 50 de golpe para hacer pruebas
            stats.SetLvFear(fearCounter);
        }
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
