using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBase : MonoBehaviour, IKillable {
    public GameObject player;
    public float gapBetweenPlayerAndEnemy = 2.5f;
    public float biggerGapBetweenPlayerAndEnemy = 15f;
    public string tagToFind = "Player";
    public AudioClip deathSFX;

    private CharacterMovement _characterMovement;
    private CharacterAnimation _characterAnimation;
    private Status _status;
    private Vector3 _randomPosition;
    private float _sphereMultiplier = 10f;
    private Vector3 direction;


    void Start() {
        player = GameObject.FindWithTag(tagToFind);

        _characterMovement = GetComponent<CharacterMovement>();
        _characterAnimation = GetComponent<CharacterAnimation>();
        _status = GetComponent<Status>();

        RandomZombieGenerator();
    }
    void FixedUpdate() {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        //direction = player.transform.position - transform.position;

        _characterMovement.Rotate(direction);

        if(distance > biggerGapBetweenPlayerAndEnemy) {
            Wander();
        }
        else if(distance > gapBetweenPlayerAndEnemy) {
            direction = player.transform.position - transform.position;

            _characterMovement.Move(direction, _status.speed);
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
    void Wander() {
        _randomPosition = RandomizePosition();
        direction = _randomPosition - transform.position;
        _characterMovement.Move(direction, _status.speed);
    }
    Vector3 RandomizePosition() {
        Vector3 position = Random.insideUnitSphere * _sphereMultiplier; //o inimigo vaga dentro desse raio criado
        position += transform.position;
        position.y = transform.position.y; //para o zumbi não subir ou descer nesse eixo

        return position;
    }

    public void TakeDamage(int damage) {
        _status.life -= damage;
        if(_status.life <= 0) {
            Death();
        }
    }

    public void Death() {
        AudioManager.instance.PlayOneShot(deathSFX);
        Destroy(gameObject);
    }
    public void GameOver() {
        
    }
}
