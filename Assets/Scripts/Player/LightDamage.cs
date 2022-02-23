<<<<<<< Updated upstream
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
            collision.gameObject.GetComponent<EnemyHealthSystem>().Damage(stats.GetAttack()*Time.deltaTime);
        }
    }
}
=======
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
            collision.gameObject.GetComponent<EnemyHealthSystem>().Damage(stats.GetAttack()*Time.deltaTime);
        }
    }
}
>>>>>>> Stashed changes
