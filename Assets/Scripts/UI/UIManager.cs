using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public Slider lifeSlider;
    public GameObject GameOverPanel;

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
    }
    public void Restart() {
        SceneManager.LoadScene("game");
    }
    
}
