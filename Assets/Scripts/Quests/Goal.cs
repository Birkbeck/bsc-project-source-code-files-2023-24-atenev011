public enum GoalType
{
    Kick,
    Kill,
}

[System.Serializable]
public class Goal
{
    public GoalType goalType;
    public int requiredAmount;
    public int currentAmount;
    public string goalDescription;
    public bool isCompleted;
}
