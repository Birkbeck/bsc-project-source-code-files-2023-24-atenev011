using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [Header("Game UI Views")]
    public GameObject menuViewUI;
    public GameObject questsUI;

    [Header("Text Elements")]
    public TextMeshProUGUI congratulations;

    public void ShowCongratulations(bool state)
    {
        congratulations.gameObject.SetActive(state);
    }
    public void SetActiveMenuView(bool state)
    {
        menuViewUI.SetActive(state);
        questsUI.gameObject.SetActive(!state);
    }

   
}
