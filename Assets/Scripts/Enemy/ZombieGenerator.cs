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
    private GameObject _player;

    void Start() {
        _player = GameObject.FindWithTag("Player");
    }

    void Update() {
        ConditionToCreateZombie();
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _multiplier);
    }

    void ConditionToCreateZombie() {
        if(Vector3.Distance(transform.position, _player.transform.position) > _distanceBetweenPlayerAndZombieCreation) {
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
        Instantiate(zombiePrefab, creationPosition, transform.rotation);
    }
    Vector3 RandomizePosition() {
        Vector3 position = Random.insideUnitSphere * _multiplier;
        position += transform.position;
        position.y = 0;

        return position;
    }
}
