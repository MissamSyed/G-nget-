using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void RestartButton() {
        SceneManager.LoadScene("Player_Leon");
    }

    public void ExitButton() {
        SceneManager.LoadScene("Kostas Main meny shity shit shit let it work");
    }
}
