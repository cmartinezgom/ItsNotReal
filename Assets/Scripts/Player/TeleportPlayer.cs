using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform destination;
    public GameObject icon;
    public GameObject candado;
    public int keysNeeded;
    public TextMesh textKeys;

    public GameObject fadeIn;
    public GameObject fadeOut;

    GameObject player;

    bool inRange;
    bool teleporting;

    public bool blocked = false;

    private void Start()
    {
        if (!blocked)
        {
            textKeys.text = "";
            candado.SetActive(false);
        }
        else
        {
            textKeys.text = keysNeeded.ToString();
        }
    }

    void Update()
    {
        if (inRange && !blocked)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!teleporting)
                {
                    player.GetComponent<PlayerMovement>().enabled = false;
                    teleporting = true;
                    StartCoroutine(Teleport());
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            if (!blocked)
            {
                icon.SetActive(true);
            }
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            icon.SetActive(false);
            inRange = false;
        }
    }

    IEnumerator Teleport()
    {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1f);
        player.transform.position = destination.position;
        yield return new WaitForSeconds(1f);
        fadeOut.SetActive(false);
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1f);
        player.GetComponent<PlayerMovement>().enabled = true;
        fadeIn.SetActive(false);
        teleporting = false;
    }

    public void Unlock()
    {
        blocked = false;
        candado.SetActive(false);
        textKeys.text = "";
    }
}
