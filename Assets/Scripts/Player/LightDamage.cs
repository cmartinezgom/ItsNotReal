using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDamage : MonoBehaviour
{
    public PlayerStats stats;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (gameObject.name.Contains("Ultimate"))
            {
                collision.gameObject.GetComponent<EnemyHealthSystem>().Damage(stats.GetAttack() * 15 * Time.deltaTime);
            }
            else
            {
                collision.gameObject.GetComponent<EnemyHealthSystem>().Damage(stats.GetAttack() * Time.deltaTime);
            }
        }
    }
}
