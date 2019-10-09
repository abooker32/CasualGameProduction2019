using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayHandler : MonoBehaviour
{
    public GameObject pauseMenu;
    public TextMeshProUGUI scoreText;
    public static int scoreAmount;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        scoreText.text = "Score: " + scoreAmount;
    }

    public void OpenPause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ClosePause()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void DebugAlert(string alert)
    {
        Debug.Log(alert);
    }
}
