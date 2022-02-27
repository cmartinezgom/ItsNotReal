using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroDialogue : MonoBehaviour
{
    public Dialogue dialogue;

    bool inDialogue = false;

    float t = 0.0f;

    public GameObject[] paneles;
    public string[] narradores;
    public int c = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!inDialogue)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                FindObjectOfType<DialogueManager>().ChangeNarrator(narradores[c]);
                StartCoroutine("WaitAndNextFrame");
                inDialogue = true;
            }
            else
            {
                if (!FindObjectOfType<DialogueManager>().HasEnded())
                {
                    FindObjectOfType<DialogueManager>().DisplayNextSentence();
                    FindObjectOfType<DialogueManager>().ChangeNarrator(narradores[c]);
                    StartCoroutine("WaitAndNextFrame");
                }
                else
                {
                    FindObjectOfType<DialogueManager>().DisplayNextSentence();
                    //StartCoroutine("WaitAndNextFrame");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }


    IEnumerator WaitAndNextFrame()
    {
        if (c < paneles.Length-1)
        {
            StartCoroutine(FadeIn(paneles[c].GetComponent<Image>()));
        }
        else
        {
            foreach (var panel in paneles)
            {
                panel.SetActive(false);
            }
            paneles[c].SetActive(true);
            StartCoroutine(FadeIn(paneles[c].GetComponent<Image>()));
            if (SceneManager.GetActiveScene().name.Contains("Intro"))
            {
                yield return new WaitForSeconds(6f);
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                yield return new WaitForSeconds(2f);
                StartCoroutine(FadeOut(paneles[c].GetComponent<Image>()));
                //Cargar créditos
                yield return new WaitForSeconds(2f);
                SceneManager.LoadScene("Credits");
            }
        }

        c++;
    }

    IEnumerator FadeIn(Image frame)
    {
        var temp = frame.color;

        for (float ft = 0f; ft <= 1.1f; ft += 0.1f)
        {
            temp.a = ft;
            frame.color = temp;
            yield return new WaitForSeconds(.05f);
        }
    }

    IEnumerator FadeOut(Image frame)
    {
        var temp = frame.color;

        for (float ft = 1f; ft >= 0f; ft -= 0.01f)
        {
            temp.a = ft;
            frame.color = temp;
            yield return new WaitForSeconds(.05f);
        }
    }
}
