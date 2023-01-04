using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossBase : MonoBehaviour {

    private Transform _player;
    private NavMeshAgent _agent;

    void Start() {
        _player = GameObject.FindWithTag("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
    }
    void Update() {
        _agent.SetDestination(_player.position);
    }

}
