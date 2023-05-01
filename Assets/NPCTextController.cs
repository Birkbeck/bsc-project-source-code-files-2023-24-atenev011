using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCTextController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public float typingSpeed = 0.02f;

    private bool isDialogueActive = false;
    private bool isSpeedingUp = false;
    private Coroutine currentCoroutine;
    private Transform npcTransform;

    public void StartDialogue(string[] sentences, Transform npcTransform)
    {
        if (!isDialogueActive)
        {
            isDialogueActive = true;
            this.npcTransform = npcTransform;
            currentCoroutine = StartCoroutine(TypeSentences(sentences));
        }
    }

    public void EndDialogue()
    {
        if (isDialogueActive)
        {
            isDialogueActive = false;
            StopCoroutine(currentCoroutine);
            dialogueText.text = "";
            dialogueText.gameObject.SetActive(false);
        }
    }

    public void SpeedUpText()
    {
        isSpeedingUp = true;
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }

    private IEnumerator TypeSentences(string[] sentences)
    {
        foreach (string sentence in sentences)
        {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                float waitTime = isSpeedingUp ? typingSpeed * 0.1f : typingSpeed;
                yield return new WaitForSeconds(waitTime);
            }
            isSpeedingUp = false;
            yield return new WaitForSeconds(1f);
        }
        EndDialogue();
    }

    public void SetDialoguePosition()
    {
        dialogueText.gameObject.SetActive(true);
        dialogueText.transform.position = dialogueText.transform.position = new Vector3(0f, 1.969f, 0.037f);
}
}