using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public float typingSpeed = 0.02f;
    private bool isActive = false;
    private bool speedingUp = false;
    private Text dialogueText;

    public void StartDialogue(string[] sentences, Text targetText)
    {
        dialogueText = targetText;
        isActive = true;
        StartCoroutine(TypeSentence(sentences));
    }

    public void SpeedUpText()
    {
        speedingUp = true;
    }

    public bool IsActive()
    {
        return isActive;
    }

    IEnumerator TypeSentence(string[] sentences)
    {
        foreach (string sentence in sentences)
        {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                float waitTime = speedingUp ? typingSpeed * 0.1f : typingSpeed;
                yield return new WaitForSeconds(waitTime);
            }
            speedingUp = false;
            yield return new WaitForSeconds(1f);
        }
        isActive = false;
        dialogueText.text = "";
    }
}
