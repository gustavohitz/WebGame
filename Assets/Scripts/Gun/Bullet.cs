using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;
    public AudioClip deathSFX;
    private Rigidbody _rigidbody;

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Update() {
        Destroy(gameObject, 1);
    }
    
    void FixedUpdate() {
        _rigidbody.MovePosition(_rigidbody.position + transform.forward * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other) {
        Quaternion rotationOppositeBullet = Quaternion.LookRotation(-transform.forward);
        //a particula de sangue vai sair na direção oposta da bala

        switch(other.tag) {
            case "Enemy":
                ZombieBase zombie = other.GetComponent<ZombieBase>();
                zombie.TakeDamage(1);
                zombie.ActivateBloodParticle(transform.position, rotationOppositeBullet);
                break;

            case "Boss":
                BossBase boss = other.GetComponent<BossBase>();
                boss.TakeDamage(1);
                boss.ActivateBloodParticle(transform.position, rotationOppositeBullet);
                break;
        }
        
        Destroy(gameObject);
    }

}
