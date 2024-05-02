using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public TextMeshProUGUI questDescription;
    public TextMeshProUGUI goalInfo;

    public void SetUp(Quest quest)
    {
        if (quest.IsCompleted())
        {
            Destroy(this.gameObject);
        }

        questDescription.text = quest.questDescription;

        string goalsText = "";
        foreach (Goal goal in quest.goals)
        {
            string goalInfo = string.Format("{0}: {1}/{2}\n", goal.goalDescription, goal.currentAmount, goal.requiredAmount);
            goalsText += goalInfo;
        }
        goalInfo.text = goalsText;
    }
}
