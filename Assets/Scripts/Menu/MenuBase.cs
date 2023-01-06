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
        StartCoroutine(ChangeScene("game"));
    }

    IEnumerator ChangeScene(string name) {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(name);
    }
    public void QuitGame() {
        StartCoroutine(Quit());
    }

    IEnumerator Quit() {
        yield return new WaitForSeconds(.5f);
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    
}
