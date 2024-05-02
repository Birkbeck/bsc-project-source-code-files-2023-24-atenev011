using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public List<Quest> activeQuests;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of QuestManager found!");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            activeQuests[i].StartQuest();
        }
    }

    private void Update()
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].IsCompleted())
            {
                activeQuests.Remove(activeQuests[i]);
            }
        }
    }

    public void AddQuest(Quest quest)
    {
        activeQuests.Add(quest);
    }

    public void UpdateQuestProgress(GoalType goalType, int amount)
    {
        foreach (Quest quest in activeQuests)
        {
            quest.UpdateProgress(goalType, amount);
        }
    }

}
