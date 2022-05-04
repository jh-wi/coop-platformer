using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    private Queue<string> sentences;
    public Dialogue dialogue;
	

    public Animator animator;
    public Animator buttonAnimator;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
		//FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		StartDialogue();
    }

    public void StartDialogue()
    {
        //animator.SetBool("isOpen", true);
        Debug.Log("Starting conversation with ");

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
		animator.gameObject.SetActive(false);
		buttonAnimator.gameObject.SetActive(false);
        //animator.SetBool("isOpen", false);
       // buttonAnimator.SetBool("isOpen", false);
        //Dubug.Log("End of Dialogue. ");
    }
}
