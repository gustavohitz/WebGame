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
    public TextMeshProUGUI hiScoreTxt;
    public TextMeshProUGUI killedZombiesAmountText;

    private PlayerController playerControllerScript;
    private float _savedHiScore;
    private int _killedZombiesAmount;

    void Start() {
        Time.timeScale = 1;

        playerControllerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        lifeSlider.maxValue = playerControllerScript.playerStatus.life;
        UpdateLifeSlider();

        _savedHiScore = PlayerPrefs.GetFloat("HiScore"); //quando começar, o jogo busca na máquina o hiscore
    }
    void AdjustHiScore(int min, int sec) {
        if(Time.timeSinceLevelLoad > _savedHiScore) {
            _savedHiScore = Time.timeSinceLevelLoad;
            hiScoreTxt.text = string.Format("HiScore = {0}min and {1}s", min, sec); //outra forma de escrever. A primeira chave vai receber min e a segunda, sec
            PlayerPrefs.SetFloat("HiScore", _savedHiScore); //salva na sua máquina. Com SetFloat pega-se um float. Demos um nome e apontamos qual variável deve ser salva
        }

        if(hiScoreTxt.text == "") { //para mostrar o HiScore quando não foi superado
            min = (int)_savedHiScore / 60;
            sec = (int)_savedHiScore % 60;
            hiScoreTxt.text = string.Format("HiScore = {0}min and {1}s", min, sec);
            PlayerPrefs.SetFloat("HiScore", _savedHiScore);
        }
    }

    public void UpdateKilledZombiesAmount() {
        _killedZombiesAmount++;

        killedZombiesAmountText.text = string.Format("x {0}", _killedZombiesAmount);
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

        AdjustHiScore(minutes, seconds);  
    }
    public void Restart() {
        SceneManager.LoadScene("game");
    }
    
}
