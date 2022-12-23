using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public LayerMask groundMask;
    public GameObject gameOver;
    public int life = 100;
    public UIManager uiManagerScript;
    
    private Vector3 direction;
    private Rigidbody _rigidbody;
    private Animator _playerAnimator;

    void Start() {
        Time.timeScale = 1;
        _rigidbody = GetComponent<Rigidbody>();
        _playerAnimator = GetComponent<Animator>();
    }

    void Update() {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        direction = new Vector3(xAxis, 0, zAxis);

        if(direction != Vector3.zero) {
            _playerAnimator.SetBool("Running", true);
        }
        else {
            _playerAnimator.SetBool("Running", false);
        }

        if(life <= 0) {
            if(Input.GetButtonDown("Fire1")) {
                SceneManager.LoadScene("game");
            }
        }
    }
    void FixedUpdate() {
        _rigidbody.MovePosition(_rigidbody.position + (direction * speed * Time.deltaTime));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        RaycastHit impact;

        if(Physics.Raycast(ray, out impact, 100, groundMask)) {
            Vector3 aimingPosition = impact.point - transform.position;

            aimingPosition.y = transform.position.y;

            Quaternion newRotation = Quaternion.LookRotation(aimingPosition);

            _rigidbody.MoveRotation(newRotation);
        }
    }

    public void TakeDamage(int damage) {
        life -= damage;
        uiManagerScript.UpdateLifeSlider();

        if(life <= 0) {
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }

}
