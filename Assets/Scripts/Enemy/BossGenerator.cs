using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour {

    private float _timeToNextBossCreation = 0;

    public float _timeBetweenBossCreation = 30f;
    public GameObject bossPrefab;

    void Start() {
        _timeToNextBossCreation = _timeBetweenBossCreation;
    }
    void Update() {
        CreateBoss();
    }

    void CreateBoss() {
        if(Time.timeSinceLevelLoad > _timeToNextBossCreation) {
            Instantiate(bossPrefab, transform.position, Quaternion.identity);
            _timeToNextBossCreation = Time.timeSinceLevelLoad + _timeBetweenBossCreation;
        }
    }
 
}
