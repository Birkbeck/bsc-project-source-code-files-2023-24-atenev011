using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public Button[] choiceButtons;

    private int playerCount;

    private string[] dialogueOptions = {"Option 1", "Option 2", "Option 3"};

    void Start()
    {
        dialogueBox.SetActive(false);
        playerCount = 0;
    }

    void Update()
    {
        if (playerCount < 5)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueBox.SetActive(true);
                dialogueText.text = "Hello! Please choose an option:";
                for (int i = 0; i < choiceButtons.Length; i++)
                {
                    choiceButtons[i].gameObject.SetActive(true);
                    choiceButtons[i].GetComponentInChildren<Text>().text = dialogueOptions[i];
                }
            }
        }
        else
        {
            dialogueBox.SetActive(false);
            for (int i = 0; i < choiceButtons.Length; i++)
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void OptionSelected(int index)
    {
        dialogueBox.SetActive(false);
        for (int i = 0; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].gameObject.SetActive(false);
        }
        switch (index)
        {
            case 0:
                dialogueText.text = "You chose Option 1";
                break;
            case 1:
                dialogueText.text = "You chose Option 2";
                break;
            case 2:
                dialogueText.text = "You chose Option 3";
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerCount--;
        }
    }
}
