using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour {

    public GameObject zombiePrefab;
    public float timeToGenerateZombie = 1f;
    public LayerMask zombieLayer;

    private float _timeCount = 0;
    private float _multiplier = 3f;
    private float _radius = 1;
    private float _distanceBetweenPlayerAndZombieCreation = 40f;
    private float _timeToIncreaseDifficulty = 15f;
    private float _difficultyTimer;
    private GameObject _player;
    private int _maximumZombieAmount = 2;
    private int _currentZombieAmount;

    void Start() {
        _player = GameObject.FindWithTag("Player");

        _difficultyTimer = _timeToIncreaseDifficulty;

        for(int i = 0; i < _maximumZombieAmount; i++) {
            StartCoroutine(CreateNewZombie());
        }
    }

    void Update() {
        ConditionToCreateZombie();
        IncreasingDifficultyLevel();
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _multiplier);
    }
    void IncreasingDifficultyLevel() {
        if(Time.timeSinceLevelLoad > _difficultyTimer) {
            _maximumZombieAmount++;
            _difficultyTimer = Time.timeSinceLevelLoad + _timeToIncreaseDifficulty;
        }
    }

    void ConditionToCreateZombie() {
        bool canGenerateZombie = Vector3.Distance(transform.position, _player.transform.position) > _distanceBetweenPlayerAndZombieCreation;

        if(canGenerateZombie == true && _currentZombieAmount < _maximumZombieAmount) {
            _timeCount += Time.deltaTime;

            if(_timeCount >= timeToGenerateZombie) {
                StartCoroutine(CreateNewZombie());
                _timeCount = 0;
            }
        }
    }
    IEnumerator CreateNewZombie() {
        Vector3 creationPosition = RandomizePosition();
        Collider[] colliders = Physics.OverlapSphere(creationPosition, _radius, zombieLayer); //pegamos uma posição e a Unity diz quem tem colisão. Quem está nessa esfera é recebido como colisor
        
        while(colliders.Length > 0) {
            creationPosition = RandomizePosition();
            colliders = Physics.OverlapSphere(creationPosition, _radius, zombieLayer);
            yield return null; //se nesse frame não achar uma posição, retorna vazio e espera o próximo
        }
        ZombieBase zombie = Instantiate(zombiePrefab, creationPosition, transform.rotation).GetComponent<ZombieBase>();
        zombie.zombieGenerator = this; //o gerador desse zumbi que foi criado é este script. Agora sabemos a partir de qual gerador o zumbi foi criado
        _currentZombieAmount++;
    }
    Vector3 RandomizePosition() {
        Vector3 position = Random.insideUnitSphere * _multiplier;
        position += transform.position;
        position.y = 0;

        return position;
    }

    public void DecreaseZombieAmount() {
        _currentZombieAmount--;
    }
}
