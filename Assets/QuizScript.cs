using UnityEngine;

public class QuizScript : MonoBehaviour
{
    public NPCInteraction npcInteraction;

    private void Start()
    {
        npcInteraction.OnQuizStart += StartQuiz;
    }

    private void OnDestroy()
    {
        npcInteraction.OnQuizStart -= StartQuiz;
    }

    private void StartQuiz()
    {
        // Your quiz logic
        Debug.Log("Starting quiz");
    }
}
