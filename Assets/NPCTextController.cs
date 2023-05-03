/// <summary>
/// Author: atenev01
/// Class for the dialogue.
/// </summary>

using System.Collections;
using TMPro;
using UnityEngine;

public class NPCTextController : MonoBehaviour
{
    public TextMeshProUGUI textObject; // Reference to text object
    public Transform npcTransform; // Reference to NPC transform
    private int currentDialogueIndex = 0; // Current dialogue index
    private bool dialogueActive = false; // Is dialogue active?
    private string[][] dialogues = new string[][] // Array of dialogue options
    {
        new string[] { "Press F" },
        new string[] { "Welcome to this buggy world traveler!" },
        new string[] { "This is an adventure in which you can choose to read this or not." },
        new string[] { "There you go, multiple choice game!" }
    };

    void Start()
    {
        if (textObject == null) // If text object is not assigned, log error message
        {
            Debug.LogError("Text object is not assigned in the NPCTextController script.");
            return;
        }

        textObject.text = dialogues[currentDialogueIndex][0]; // Set initial dialogue text
    }

    public void StartDialogue(string[] dialogueText, Transform npcTransform)
    {
        if (currentDialogueIndex < dialogues.Length) // If there are more dialogues available
        {
            textObject.text = dialogues[currentDialogueIndex][0]; // Set dialogue text
            dialogueActive = true; // Set dialogue to active
        }
        else
        {
            dialogueActive = false; // Set dialogue to inactive
        }
    }

    public void EndDialogue()
    {
        textObject.text = ""; // Clear text
        dialogueActive = false; // Set dialogue to inactive
        currentDialogueIndex++; // Move to next dialogue
    }

    public bool IsDialogueActive()
    {
        return dialogueActive; // Return whether dialogue is active
    }
}
