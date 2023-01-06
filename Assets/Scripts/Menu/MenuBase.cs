using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBase : MonoBehaviour {

    public GameObject quitButton;

    void Start() {
        #if UNITY_STANDALONE || UNITY_EDITOR
        quitButton.SetActive(true);
        #endif //o código só vai ser chamado se o jogo estiver rodando como aplicativo de PC, Mac, Linux
    }

    public void PlayGame() {
        SceneManager.LoadScene("game");
    }
    public void QuitGame() {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    
}
