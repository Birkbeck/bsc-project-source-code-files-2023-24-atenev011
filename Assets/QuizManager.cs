using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public GameObject quizPanel;
    public List<string> questions;
    public Text questionText;
    public Button option1Button;
    public Button option2Button;
    public PlayerMovement playerMovement;
    public CameraFollow cameraFollow;

    private int currentQuestionIndex = 0;

    private void Awake()
    {
        quizPanel.SetActive(false);
    }

    public void StartQuiz()
    {
        playerMovement.enabled = false;
        cameraFollow.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        quizPanel.SetActive(true);
        ShowQuestion(currentQuestionIndex);
    }

    public void EndQuiz()
    {
        quizPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerMovement.enabled = true;
        cameraFollow.enabled = true;
        currentQuestionIndex = 0;
    }

    public void ShowQuestion(int index)
    {
        questionText.text = questions[index];
    }

    public void OnOptionClicked(int option)
    {
        // Implement your logic here based on the option selected
        if (currentQuestionIndex < questions.Count - 1)
        {
            currentQuestionIndex++;
            ShowQuestion(currentQuestionIndex);
        }
        else
        {
            EndQuiz();
        }
    }
}
