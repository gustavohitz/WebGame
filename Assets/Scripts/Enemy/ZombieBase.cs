using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBase : MonoBehaviour {
    public GameObject player;
    public float speed = 5;
    public float gapBetweenPlayerAndEnemy = 2.5f;
    public string tagToFind = "Player";

    private CharacterMovement _characterMovement;
    private CharacterAnimation _characterAnimation;


    void Start() {
        player = GameObject.FindWithTag(tagToFind);

        _characterMovement = GetComponent<CharacterMovement>();
        _characterAnimation = GetComponent<CharacterAnimation>();

        RandomZombieGenerator();
    }
    void FixedUpdate() {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        Vector3 direction = player.transform.position - transform.position;

        _characterMovement.Rotate(direction);

        if(distance > gapBetweenPlayerAndEnemy) {
            _characterMovement.Move(direction, speed);
            _characterAnimation.AttackAnimation(false);
        }
        else {
            _characterAnimation.AttackAnimation(true);
        }
    }
    
    void EnemyAttack() {
        int causeDamage = Random.Range(20, 30);
        player.GetComponent<PlayerController>().TakeDamage(causeDamage);
    }

    void RandomZombieGenerator() {
        int generateZombieType = Random.Range(1, 28); //um a mais do que a quantidade certa
        transform.GetChild(generateZombieType).gameObject.SetActive(true);
    }
}
