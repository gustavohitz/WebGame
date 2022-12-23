using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBase : MonoBehaviour {
    public GameObject player;
    public float speed = 5;
    public float gapBetweenPlayerAndEnemy = 2.5f;
    public string tagToFind = "Player";

    private Rigidbody _rigidbody;
    private Animator _zombieAnimator;


    void Start() {
        player = GameObject.FindWithTag(tagToFind);
        int generateZombieType = Random.Range(1, 28); //um a mais do que a quantidade certa
        transform.GetChild(generateZombieType).gameObject.SetActive(true);

        _rigidbody = GetComponent<Rigidbody>();
        _zombieAnimator = GetComponent<Animator>();
    }
    void FixedUpdate() {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        Vector3 direction = player.transform.position - transform.position;

        Quaternion newRotation = Quaternion.LookRotation(direction);
        _rigidbody.MoveRotation(newRotation);

        if(distance > gapBetweenPlayerAndEnemy) {
            _rigidbody.MovePosition(_rigidbody.position + (direction.normalized * speed * Time.deltaTime));
            _zombieAnimator.SetBool("Attacking", false);
        }
        else {
            _zombieAnimator.SetBool("Attacking", true);
        }
    }
    
    void EnemyAttack() {
        int causeDamage = Random.Range(20, 30);
        player.GetComponent<PlayerController>().TakeDamage(causeDamage);
    }
}
