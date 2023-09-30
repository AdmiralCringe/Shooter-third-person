using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI sentenceText;

    private void Start()
    {
        sentences = new Queue<string>();
        
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        print("начали");
        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }

    public void DisplayNextSentences()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        sentenceText.text = sentence;
    }

    public void EndDialogue()
    {
        print("всё");
    }
}