using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.FilePathAttribute;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameUIManager gameUIManager;
    public bool isPaused = false;

    private Vector3 questStartPos;
    public GameObject player;

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Pause();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }


    #region UI Button Related

    public void Play()
    {
        gameUIManager.SetActiveMenuView(false);
        Time.timeScale = 1;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        gameUIManager.SetActiveMenuView(true);
        Time.timeScale = 0;
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    #endregion

    #region UI Text Elements

    public void ShowCongratulations()
    {
        StartCoroutine(ShowAndHideCoroutine());
    }

    IEnumerator ShowAndHideCoroutine()
    {
        gameUIManager.ShowCongratulations(true);

        yield return new WaitForSeconds(5f);

        gameUIManager.ShowCongratulations(false);
    }

    #endregion

    #region Quest Related

    public void GetCurrentPosition()
    {
        questStartPos = player.transform.position;
    }

    public void ResetPosition()
    {
        CharacterController characterController = player.GetComponent<CharacterController>();
        characterController.enabled = false;
        player.transform.position = questStartPos;
        characterController.enabled = true;
    }
    #endregion
}
