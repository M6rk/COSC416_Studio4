using TMPro;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int score = 0;
    [SerializeField] private CoinCounterUI coinCounter;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject settingsMenu;

    // Change to a regular field
    private bool isSettingsMenuActive;
    public bool IsSettingsMenuActive => isSettingsMenuActive;

    // Optional: Add a read-only property if you need external access
    // public bool IsSettingsMenuActive => isSettingsMenuActive;

    protected override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        inputManager.OnSettingsMenu.AddListener(ToggleSettingsMenu);
        // the game starts with the settings menu disabled
        DisableSettingsMenu();
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    private void ToggleSettingsMenu()
    {
        if (isSettingsMenuActive) DisableSettingsMenu();
        else EnableSettingsMenu();
    }

    private void EnableSettingsMenu()
    {
        Time.timeScale = 0f;
        settingsMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isSettingsMenuActive = true;
    }

    public void DisableSettingsMenu()
    {
        Time.timeScale = 1f;
        settingsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isSettingsMenuActive = false;
    }

    public void IncreaseScore()
    {
        score++;
        coinCounter.UpdateScore(score);
    }
}