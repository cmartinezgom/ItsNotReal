using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    EnemyStats stats;
    public SpriteRenderer sprite;

    public float minTransparency = 0.3f;

    void Start()
    {
        stats = GetComponent<EnemyStats>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Damage(0.1f);
        }
    }


    public void Damage(float damage)
    {
        stats.Damage(damage);
        //Actualizar UI
        //Actualizar transparencia enemigo
        var temp = sprite.color;

        temp.a = stats.GetHealth() / stats.GetMaxHealth() + minTransparency;

        sprite.color = temp;
    }

    public void Heal(float heal)
    {
        stats.Heal(heal);
        //Actualizar UI
        //Actualizar transparencia enemigo

    }
}
