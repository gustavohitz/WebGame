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
        switch(other.tag) {
            case "Enemy":
                other.GetComponent<ZombieBase>().TakeDamage(1);
                break;

            case "Boss":
                other.GetComponent<BossBase>().TakeDamage(1);
                break;
        }
        /*if(other.tag == "Enemy") {
            other.GetComponent<ZombieBase>().TakeDamage(1);
        }
        else if(other.tag == "Boss") {
            other.GetComponent<BossBase>().TakeDamage(1);
        }*/
        
        Destroy(gameObject);
    }

}
