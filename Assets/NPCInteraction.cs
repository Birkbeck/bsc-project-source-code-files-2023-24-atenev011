using System;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask playerLayer;

    public event Action OnQuizStart; // Add event for starting the quiz

    private bool isPlayerInRange;

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionDistance, playerLayer);

        isPlayerInRange = colliders.Length > 0;

        if (isPlayerInRange && Input.GetMouseButtonDown(0))
        {
            StartQuiz();
        }
    }

    private void StartQuiz()
    {
        OnQuizStart?.Invoke(); // Trigger the event when starting the quiz
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}
