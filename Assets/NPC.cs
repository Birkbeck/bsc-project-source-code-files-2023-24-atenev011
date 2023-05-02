using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public string[] sentences;
    public float interactionRange = 3f;
    public GameObject player;

    private NPCTextController textController;
    private bool playerInRange = false;

    void Start()
    {
        textController = FindObjectOfType<NPCTextController>();
        if (!textController)
        {
            Debug.LogError("NPCTextController not found in the scene. Please add an NPCTextController to the scene.");
        }
    }

    void Update()
    {
        playerInRange = Vector3.Distance(transform.position, player.transform.position) < interactionRange;
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (textController && !textController.IsDialogueActive())
            {
                textController.StartDialogue(sentences, transform);
            }
            else if (textController && textController.IsDialogueActive())
            {
                textController.EndDialogue();
            }
        }
    }
}
