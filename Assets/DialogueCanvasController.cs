/// <summary>
/// Author: atenev01
/// Class for canvas and its position.
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject dialogueCanvasPrefab; // Prefab for dialogue canvas

    public GameObject CreateDialogueCanvas(Transform npcTransform) // Create dialogue canvas at position of NPC
    {
        GameObject dialogueCanvasInstance = Instantiate(dialogueCanvasPrefab, transform); // Instantiate dialogue canvas
        dialogueCanvasInstance.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(npcTransform.position); // Set position of dialogue canvas to screen position of NPC
        return dialogueCanvasInstance;
    }
}
