using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider lifeSlider;

    private PlayerController playerControllerScript;

    void Start() {
        playerControllerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        lifeSlider.maxValue = playerControllerScript.playerStatus.life;
        UpdateLifeSlider();
    }

    public void UpdateLifeSlider() {
        lifeSlider.value = playerControllerScript.playerStatus.life;
    }
    
}
