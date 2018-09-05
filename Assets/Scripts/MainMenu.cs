using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayAttackStyle() {
        SceneManager.LoadScene("AttackPlayStyle");
    }

    public void PlayDefendStyle()
    {
        SceneManager.LoadScene("DefenderPlayStyle");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
