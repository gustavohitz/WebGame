using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGenerator : MonoBehaviour {

    public GameObject zombiePrefab;
    public float timeToGenerateZombie = 1f;

    private float _timeCount = 0;

    void Update() {
        _timeCount += Time.deltaTime;

        if(_timeCount >= timeToGenerateZombie) {
            Instantiate(zombiePrefab, transform.position, transform.rotation);
            _timeCount = 0;
        }
    }
}
