using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour {

    private float _timeToNextBossCreation = 0;
    private UIManager _uiManagerScript;

    public float timeBetweenBossCreation = 30f;
    public GameObject bossPrefab;

    void Start() {
        _timeToNextBossCreation = timeBetweenBossCreation;
        _uiManagerScript = GameObject.FindObjectOfType(typeof(UIManager)) as UIManager;
    }
    void Update() {
        CreateBoss();
    }

    void CreateBoss() {
        if(Time.timeSinceLevelLoad > _timeToNextBossCreation) {
            Instantiate(bossPrefab, transform.position, Quaternion.identity);
            _uiManagerScript.ShowBossWarningText();
            _timeToNextBossCreation = Time.timeSinceLevelLoad + timeBetweenBossCreation;
        }
    }
 
}
