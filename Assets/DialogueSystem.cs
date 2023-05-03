/// <summary>
/// Author: atenev01
/// Class for text speed.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text dialogueText; // Text object to display dialogue
    public float typingSpeed = 0.02f; // Speed of text typing
    private bool isActive = false; // Is dialogue currently active
    private bool speedingUp = false; // Is text currently speeding up

    public void StartDialogue(string[] sentences) // Start dialogue with given sentences
    {
        isActive = true; // Set dialogue to active
        StartCoroutine(TypeSentence(sentences)); // Start typing sentences
    }

    public void SpeedUpText() // Speed up text
    {
        speedingUp = true;
    }

    public bool IsActive() // Check if dialogue is active
    {
        return isActive;
    }

    IEnumerator TypeSentence(string[] sentences) // Coroutine to type out each sentence
    {
        foreach (string sentence in sentences)
        {
            dialogueText.text = ""; // Clear the initial text
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter; // Add each letter to the text
                float waitTime = speedingUp ? typingSpeed * 0.1f : typingSpeed; // Adjust wait time based on whether text is speeding up or not
                yield return new WaitForSeconds(waitTime); // Wait before adding next letter
            }
            speedingUp = false; // Reset speedingUp
            yield return new WaitForSeconds(1f); // Wait after sentence is fully typed
        }
        isActive = false; // Set dialogue to inactive
    }
}
