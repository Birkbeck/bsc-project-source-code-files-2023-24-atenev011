using UnityEngine;

public class NPCQuizInteraction : MonoBehaviour
{
    public float interactionDistance = 3f;
    public QuizManager quizManager;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(transform.position, playerTransform.position) <= interactionDistance)
        {
            quizManager.StartQuiz();
        }
    }
}
