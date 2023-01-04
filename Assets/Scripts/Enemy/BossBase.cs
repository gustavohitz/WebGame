using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossBase : MonoBehaviour, IKillable {

    private Transform _player;
    private NavMeshAgent _agent;
    private Status _bossStatus;
    private CharacterAnimation _bossAnimation;
    private CharacterMovement _bossMovement;
    private float _timeToDestroyGameObject = 2f;

    public GameObject medkitPrefab;

    void Start() {
        _player = GameObject.FindWithTag("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
        _bossStatus = GetComponent<Status>();
        _agent.speed = _bossStatus.speed;
        _bossAnimation = GetComponent<CharacterAnimation>();
        _bossMovement = GetComponent<CharacterMovement>();
    }
    void FixedUpdate() {
        _agent.SetDestination(_player.position);
        _bossAnimation.RunningAnimation(_agent.velocity.magnitude);

        if(_agent.hasPath == true) { //se a Unity já calculou um destino para o agente.
            bool isNearPlayer = _agent.remainingDistance <= _agent.stoppingDistance;

            if(isNearPlayer) {
                Attack();

                Vector3 direction = _player.position - transform.position;
                _bossMovement.SmoothRotation(direction);
            }
            else {
                NotAttacking();
            }
        }
    }
    void Attack() {
        _bossAnimation.AttackAnimation(true);
    }
    void NotAttacking() {
        _bossAnimation.AttackAnimation(false);
    }
    void EnemyAttack() {
        int causeDamage = Random.Range(30, 40);
        _player.GetComponent<PlayerController>().TakeDamage(causeDamage);
    }

    public void TakeDamage(int damage) {
        _bossStatus.life -= damage;
        if(_bossStatus.life <= 0) {
            Death();
        }
    }

    public void Death() {
        _bossAnimation.DeathAnimation();
        _bossMovement.FallAfterDeath();
        this.enabled = false;
        _agent.enabled = false;
        Instantiate(medkitPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, _timeToDestroyGameObject);
    }
}
