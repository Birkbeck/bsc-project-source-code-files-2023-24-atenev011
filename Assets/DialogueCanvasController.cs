using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject dialogueCanvasPrefab;

    public GameObject CreateDialogueCanvas(Transform npcTransform)
    {
        GameObject dialogueCanvasInstance = Instantiate(dialogueCanvasPrefab, transform);
        dialogueCanvasInstance.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(npcTransform.position);
        return dialogueCanvasInstance;
    }
}
