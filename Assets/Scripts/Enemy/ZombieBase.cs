using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBase : MonoBehaviour, IKillable {
    public GameObject player;
    public float gapBetweenPlayerAndEnemy = 2.5f;
    public float biggerGapBetweenPlayerAndEnemy = 15f;
    public string tagToFind = "Player";
    public AudioClip deathSFX;
    public GameObject medkitPrefab;
    
    [HideInInspector]
    public ZombieGenerator zombieGenerator;

    private CharacterMovement _characterMovement;
    private CharacterAnimation _characterAnimation;
    private EnemyStatus _enemyStatus;
    private Vector3 _randomPosition;
    private Vector3 direction;
    private float _sphereMultiplier = 10f;
    private float _wanderTimer;
    private float _chanceOfCreatingMedkit = 0.1f;
    private float _timeToDestroyObject = 2f;
    private UIManager _uIManagerScript;


    void Start() {
        player = GameObject.FindWithTag(tagToFind);

        _characterMovement = GetComponent<CharacterMovement>();
        _characterAnimation = GetComponent<CharacterAnimation>();
        _enemyStatus = GetComponent<EnemyStatus>();
        _uIManagerScript = GameObject.FindObjectOfType(typeof(UIManager)) as UIManager; //se não tiver o "as" ele procura como GameObejct. O as converte em script

        RandomZombieGenerator();
    }
    void FixedUpdate() {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        _characterMovement.Rotate(direction);

        _characterAnimation.RunningAnimation(direction.magnitude);

        if(distance > biggerGapBetweenPlayerAndEnemy) {
            Wander();
        }
        else if(distance > gapBetweenPlayerAndEnemy) {
            PursuitPlayer();
        }
        else {
            PlayAttackAnimation();
        }
    }
    
    void EnemyAttack() {
        int causeDamage = Random.Range(20, 30);
        player.GetComponent<PlayerController>().TakeDamage(causeDamage);
    }

    void RandomZombieGenerator() {
        int generateZombieType = Random.Range(1, transform.childCount); //um a mais do que a quantidade certa
        transform.GetChild(generateZombieType).gameObject.SetActive(true);
    }
    void Wander() {
        _wanderTimer -= Time.deltaTime;
        if(_wanderTimer <= 0) {
            _randomPosition = RandomizePosition();
            _wanderTimer += _enemyStatus.timeBetweenRandomPosition + Random.Range(-1f, 1f);
        }

        bool isNearEnough = Vector3.Distance(transform.position, _randomPosition) <= 0.05; //isso é um teste que retorna um valor verdadeiro ou falso

        if(isNearEnough == false) {
            direction = _randomPosition - transform.position;
            _characterMovement.Move(direction, _enemyStatus.speed);
        }
    }
    void PursuitPlayer() {
        direction = player.transform.position - transform.position;

        _characterMovement.Move(direction, _enemyStatus.speed);
        _characterAnimation.AttackAnimation(false);
    }
    void PlayAttackAnimation() {
        direction = player.transform.position - transform.position;

        _characterAnimation.AttackAnimation(true);
    }
    Vector3 RandomizePosition() {
        Vector3 position = Random.insideUnitSphere * _sphereMultiplier; //o inimigo vaga dentro desse raio criado
        position += transform.position;
        position.y = transform.position.y; //para o zumbi não subir ou descer nesse eixo

        return position;
    }

    public void TakeDamage(int damage) {
        _enemyStatus.life -= damage;
        if(_enemyStatus.life <= 0) {
            Death();
        }
    }

    public void Death() {
        AudioManager.instance.PlayOneShot(deathSFX);
        Destroy(gameObject, _timeToDestroyObject);
        _characterAnimation.DeathAnimation();
        _characterMovement.FallAfterDeath();
        this.enabled = false;
        RandomizeMedkitCreation(_chanceOfCreatingMedkit);
        _uIManagerScript.UpdateKilledZombiesAmount();
        zombieGenerator.DecreaseZombieAmount();
    }

    void RandomizeMedkitCreation(float creationPercentage) {
        if(Random.value <= creationPercentage) {
            Instantiate(medkitPrefab, transform.position, Quaternion.identity); //rotacão zerada
        }
    }
}
