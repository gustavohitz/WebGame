using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public LayerMask groundMask;
    public GameObject gameOver;
    public UIManager uiManagerScript;
    public AudioClip damageSFX;
    public Status playerStatus;
    
    private Vector3 _direction;
    private PlayerMovement _playerMovement;
    private CharacterAnimation _playerAnimation;

    void Start() {
        Time.timeScale = 1;
        
        playerStatus = GetComponent<Status>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimation = GetComponent<CharacterAnimation>();
    }

    void Update() {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        _direction = new Vector3(xAxis, 0, zAxis);

        _playerAnimation.PlayerRunningAnimation(_direction.magnitude); //magnitude = tamanho do vetor

        if(playerStatus.life <= 0) {
            if(Input.GetButtonDown("Fire1")) {
                SceneManager.LoadScene("game");
            }
        }
    }
    void FixedUpdate() {
        _playerMovement.Move(_direction, playerStatus.speed);

        _playerMovement.PlayerRotation(groundMask);
    }

    public void TakeDamage(int damage) {
        playerStatus.life -= damage;
        uiManagerScript.UpdateLifeSlider();
        AudioManager.instance.PlayOneShot(damageSFX);

        if(playerStatus.life <= 0) {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }

}
