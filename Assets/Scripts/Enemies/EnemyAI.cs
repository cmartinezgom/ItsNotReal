using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [HideInInspector] public EnemyStats stats;

    [HideInInspector] public GameObject player;
    //[HideInInspector] public PlayerStats playerStats;

    //public IEnemyState currentState;

    float t = 0.0f;

    void Start()
    {
        stats = GetComponent<EnemyStats>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float step;

        float playerDistance = Vector2.Distance(transform.position, player.transform.position);

        switch (stats.GetEnemyType())
        {
            case EnemyType.Chase:
                step = stats.GetSpeed() * Time.deltaTime;
                if (playerDistance >= 0f)           // Te persigue hasta que te toque
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
                }
                break;
            case EnemyType.Ranged:
                if (playerDistance <= stats.GetDistance() && playerDistance >= stats.GetDistance() - 2f)
                {
                    if (t > stats.GetCoolDown())
                    {
                        Shoot();
                        t = 0.0f;
                    }
                }
                else if (playerDistance <= stats.GetDistance()-2f)
                {
                    if (t > stats.GetCoolDown())
                    {
                        Shoot();
                        t = 0.0f;
                    }

                    step = stats.GetSpeed() * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -step);
                }
                else
                {
                    step = stats.GetSpeed() * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
                }
                break;
            case EnemyType.Retreat:
                if (playerDistance <= stats.GetDistance())
                {
                    step = stats.GetSpeed() * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -step);
                }
                else
                {

                }
                break;
            case EnemyType.Static:
                return;
            case EnemyType.Pasive:
                //step = stats.GetSpeed() * Time.deltaTime;
                //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
                break;
        }
        //currentState.UpdateState();

        t += Time.deltaTime;
    }

    void Shoot()
    {
        var direction = player.transform.position - transform.position;

        var bullet = Instantiate(stats.GetProyectile(), transform.position, Quaternion.identity);

        var rb = bullet.GetComponent<Rigidbody2D>();
        //bullet.transform.LookAt(player.transform.position);
        bullet.transform.right = player.transform.position - bullet.transform.position;
        rb.AddForce(direction * stats.GetBulletForce(), ForceMode2D.Impulse);
    }

}
