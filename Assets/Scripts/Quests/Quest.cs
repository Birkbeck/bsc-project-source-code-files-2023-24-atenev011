using UnityEngine.Events;

[System.Serializable]
public class Quest
{
    public int questID;
    public string questName;
    public string questDescription;
    public Goal[] goals;

    public UnityEvent onQuestStart = new UnityEvent();
    public UnityEvent onQuestCompleted = new UnityEvent();

    public void StartQuest()
    {
        onQuestStart.Invoke();
    }

    public bool IsCompleted()
    {
        foreach (Goal goal in goals)
        {
            if (!goal.isCompleted)
            {
                return false;
            }
        }
        return true;
    }

    public void UpdateProgress(GoalType goalType, int amount)
    {
        foreach (Goal goal in goals)
        {
            if (goal.goalType == goalType)
            {
                goal.currentAmount += amount;

                if (goal.currentAmount >= goal.requiredAmount)
                {
                    goal.isCompleted = true;
                }
            }
        } 

        if (IsCompleted())
        {
            onQuestCompleted.AddListener(GameManager.Instance.ShowCongratulations);
            onQuestCompleted.Invoke();
        }
    }
}