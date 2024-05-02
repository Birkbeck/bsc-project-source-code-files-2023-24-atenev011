using System.Collections.Generic;
using UnityEngine;

public class QuestUIManager : MonoBehaviour
{
    public GameObject questUIPrefab; 
    public Transform questUIParent;

    private List<GameObject> questUIInstances = new List<GameObject>();

    void Start()
    {
        questUIInstances = new List<GameObject>();
        foreach (Quest quest in QuestManager.Instance.activeQuests)
        {
            SpawnQuestUIPrefab(quest);
        }
    }

    void Update()
    {
        UpdateQuestUIPrefabs();
    }

    void SpawnQuestUIPrefab(Quest quest)
    {
        GameObject questUIInstance = Instantiate(questUIPrefab, questUIParent);

        QuestUI questUI = questUIInstance.GetComponent<QuestUI>();
        questUI.SetUp(quest);

        questUIInstances.Add(questUIInstance);
    }
    void UpdateQuestUIPrefabs()
    {
        for (int i = 0; i < QuestManager.Instance.activeQuests.Count; i++)
        {
            Quest quest = QuestManager.Instance.activeQuests[i];
            GameObject questUIInstance = questUIInstances[i];

            QuestUI questUI = questUIInstance.GetComponent<QuestUI>();
            questUI.SetUp(quest);
        }
    }

}

