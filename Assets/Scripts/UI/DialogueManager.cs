using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject flechita;

    public Animator animator;

    private float textSpeed;

    Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }


    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        textSpeed = dialogue.textSpeed;

        sentences.Clear();

        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        flechita.SetActive(false);

        if (sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (var letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        flechita.SetActive(true);
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    public bool HasEnded()
    {
        if (sentences.Count == 0)
        {
            return true;
        }
        return false;
    }

    public void ChangeNarrator(string newNarrator)
    {
        nameText.text = newNarrator;
    }
}
