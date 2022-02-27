using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public Text keyCount;

    private void Start()
    {
        keyCount = GameObject.Find("KeyCount").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int keys = int.Parse(keyCount.text);

            keys++;

            keyCount.text = keys.ToString();

            FindObjectOfType<AudioManager>().Play("KeyPickUp");

            Destroy(gameObject);
        }
    }
}
