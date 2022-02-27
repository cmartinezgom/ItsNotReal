using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject icon;

    bool inRange = false;
    bool inDialogue = false;
    
    private void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!inDialogue)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                    inDialogue = true;
                }
                else
                {
                    if (!FindObjectOfType<DialogueManager>().HasEnded())
                    {
                        FindObjectOfType<DialogueManager>().DisplayNextSentence();
                    }
                    else
                    {
                        FindObjectOfType<DialogueManager>().DisplayNextSentence();
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
                        StartCoroutine(ResetDialogue());
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            icon.SetActive(true);
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

    IEnumerator ResetDialogue()
    {
        yield return new WaitForSeconds(0.01f);
        inDialogue = false;
    }
}
