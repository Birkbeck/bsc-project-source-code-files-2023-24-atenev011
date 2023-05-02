using System.Collections;
using TMPro;
using UnityEngine;

public class NPCTextController : MonoBehaviour
{
    public TextMeshProUGUI textObject;
    public Transform npcTransform;
    private int currentDialogueIndex = 0;
    private bool dialogueActive = false;
    private string[][] dialogues = new string[][]
    {
        new string[] { "Press F" },
        new string[] { "Welcome to this buggy world traveler!" },
        new string[] { "This is an adventure in which you can choose to read this or not." },
        new string[] { "There you go, multiple choice game!" }
    };

    void Start()
    {
        if (textObject == null)
        {
            Debug.LogError("Text object is not assigned in the NPCTextController script.");
            return;
        }

        textObject.text = dialogues[currentDialogueIndex][0];
    }

    public void StartDialogue(string[] dialogueText, Transform npcTransform)
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            textObject.text = dialogues[currentDialogueIndex][0];
            dialogueActive = true;
        }
        else
        {
            dialogueActive = false;
        }
    }

    public void EndDialogue()
    {
        textObject.text = "";
        dialogueActive = false;
        currentDialogueIndex++;
    }

    public bool IsDialogueActive()
    {
        return dialogueActive;
    }
}
