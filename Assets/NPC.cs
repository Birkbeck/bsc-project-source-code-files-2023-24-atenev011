/// <summary>
/// Author: atenev01
/// Class for NPC interactions.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public string[] sentences; // Dialogue lines for NPC
    public float interactionRange = 3f; // Maximum interaction range
    public GameObject player; // Reference to player game object

    private NPCTextController textController; // Reference to dialogue controller
    private bool playerInRange = false; // Is player in range?

    void Start()
    {
        textController = FindObjectOfType<NPCTextController>(); // Find dialogue controller
        if (!textController) // If not found, log error message
        {
            Debug.LogError("NPCTextController not found in the scene. Please add an NPCTextController to the scene.");
        }
    }

    void Update()
    {
        playerInRange = Vector3.Distance(transform.position, player.transform.position) < interactionRange; // Check if player is in range
        if (playerInRange && Input.GetKeyDown(KeyCode.F)) // If player is in range and F key is pressed
        {
            if (textController && !textController.IsDialogueActive()) // If dialogue controller is found and dialogue is not active
            {
                textController.StartDialogue(sentences, transform); // Start dialogue
            }
            else if (textController && textController.IsDialogueActive()) // If dialogue controller is found and dialogue is active
            {
                textController.EndDialogue(); // End dialogue
            }
        }
    }
}
