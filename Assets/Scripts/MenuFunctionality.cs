using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctionality : MonoBehaviour {

    public void PlayGame() {
        SceneManager.LoadScene("DefenderPlayStyle");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
