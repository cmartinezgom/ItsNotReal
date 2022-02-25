using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemyFX : MonoBehaviour
{
    SpriteRenderer sprite;
    GameObject player;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player.transform.position.x < this.transform.position.x)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        //sprite.flipX = player.transform.position.x < this.transform.position.x;
    }
}
