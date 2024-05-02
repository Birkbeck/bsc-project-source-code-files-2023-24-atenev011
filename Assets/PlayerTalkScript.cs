using UnityEngine;

public class PlayerTalkScript : MonoBehaviour
{
    public NPCInteraction npcInteraction;

    private void Start()
    {
        npcInteraction.OnQuizStart += StartConversation;
    }

    private void OnDestroy()
    {
        npcInteraction.OnQuizStart -= StartConversation;
    }

    private void StartConversation()
    {
        // Your conversation logic with the NPC
        Debug.Log("Starting conversation with NPC");
    }
}
