using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPlayerController : MonoBehaviour
{
    [SerializeField]
    private Player playerCharacter;

    [SerializeField]
    private TMP_Text playerHealth;

    [SerializeField]
    private RectTransform statsPanel;

    [SerializeField]
    private RectTransform pauseMenu;

    public static UIPlayerController instance;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        playerHealth.text = $"{playerCharacter.GetCurrentHP()} / {playerCharacter.GetMaxHP()}";
    }

    private void Update()
    {
        ShowPlayerStats();
        PauseGame();
    }

    public void ShowPlayerStats()
    {
        print("called");
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!statsPanel.gameObject.activeInHierarchy)
            {
                statsPanel.gameObject.SetActive(true);
            }
            else
            {
                statsPanel.gameObject.SetActive(false);
            }
        }
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.gameObject.activeInHierarchy)
            {
                Time.timeScale = 0f;
                pauseMenu.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pauseMenu.gameObject.SetActive(false);
            }
        }
    }
}
