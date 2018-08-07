using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField]
    private GameObject _pauseMenuUI;

    [SerializeField]
    private GameObject _mainCanvasUI;

    [SerializeField]
    private GameObject _infoText;

    public void MainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

    public void ExitGame() {
        Logger.LogMessage("Have Fun!");
        Application.Quit();
    }

    public void Retume() {
        _pauseMenuUI.SetActive(false);
        _mainCanvasUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Pause() {
        _pauseMenuUI.SetActive(true);
        _mainCanvasUI.SetActive(false);
        _infoText.SetActive(false);
        Time.timeScale = 0f;
    }

}
