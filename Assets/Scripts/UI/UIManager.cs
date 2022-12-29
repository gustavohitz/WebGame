using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour {

    public Slider lifeSlider;
    public GameObject GameOverPanel;
    public TextMeshProUGUI survivingTimeTxt;

    private PlayerController playerControllerScript;

    void Start() {
        Time.timeScale = 1;

        playerControllerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        lifeSlider.maxValue = playerControllerScript.playerStatus.life;
        UpdateLifeSlider();
    }

    public void UpdateLifeSlider() {
        lifeSlider.value = playerControllerScript.playerStatus.life;
    }
    public void ShowGameOverPanel() {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;

        int minutes = (int)(Time.timeSinceLevelLoad / 60); //os parênteses convertem o que vem depois para inteiro
        int seconds = (int)(Time.timeSinceLevelLoad % 60); //a porcentagem (módulo) guarda o resto da divisão

        survivingTimeTxt.text = "You have survived for " + minutes + "min and " + seconds + "s";  
    }
    public void Restart() {
        SceneManager.LoadScene("game");
    }
    
}
