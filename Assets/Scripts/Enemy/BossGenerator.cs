using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour {

    private float _timeToNextBossCreation = 0;
    private UIManager _uiManagerScript;
    private Transform _player;

    public float timeBetweenBossCreation = 30f;
    public GameObject bossPrefab;
    public Transform[] possibleCreationPosition;

    void Start() {
        _timeToNextBossCreation = timeBetweenBossCreation;
        _uiManagerScript = GameObject.FindObjectOfType(typeof(UIManager)) as UIManager;
        _player = GameObject.FindWithTag("Player").transform;
    }
    void Update() {
        CreateBoss();
    }

    void CreateBoss() {
        if(Time.timeSinceLevelLoad > _timeToNextBossCreation) {
            Vector3 creationPosition = CalculateFarthestPositionFromPlayer();
            Instantiate(bossPrefab, creationPosition, Quaternion.identity);
            _uiManagerScript.ShowBossWarningText();
            _timeToNextBossCreation = Time.timeSinceLevelLoad + timeBetweenBossCreation;
        }
    }

    Vector3 CalculateFarthestPositionFromPlayer() {
        Vector3 farthestPosition = Vector3.zero;
        float greatestDistance = 0;

        foreach(Transform position in possibleCreationPosition) {
            float distanceToPlayer = Vector3.Distance(position.position, _player.position); //calculei a distância entre a primeira posição e o jogador
            if(distanceToPlayer > greatestDistance) {
                greatestDistance = distanceToPlayer;
                farthestPosition = position.position;
            }
        }
        return farthestPosition;
        /*Na posição 0, calculamos a distância entre ela e o jogador, e salvamos na variável
        distanceBewteenPlayer. A maior distância salva é o float fora do foreach. Agora, a maior
        distância salva passa a ser a distanceBetween..., já que ela vai ser sempre maior
        do que zero. A greatestDistance passa a ser essa da posição 0. Depois vamos para a 
        posição 1 e calculamos a distância entre ela e o jogador. Se a distância de P1 for maior
        do que aquela salva em P0, salvamos ela de novo. Se não for, vamos para a P2. No final
        salva-se a posição de maior distância na variável farthestPosition e a retornamos. */
    }
 
}
