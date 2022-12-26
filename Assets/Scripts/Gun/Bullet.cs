using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;
    public float timeToDestroy = 3f;
    public string tagToCheck = "Enemy";
    public AudioClip deathSFX;

    private Rigidbody _rigidbody;

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate() {
        _rigidbody.MovePosition(_rigidbody.position + transform.forward * speed * Time.deltaTime);
        Destroy(gameObject, timeToDestroy);
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == tagToCheck) {
            AudioManager.instance.PlayOneShot(deathSFX);
            Destroy(other.gameObject);
        }
        
        Destroy(gameObject);
    }

}
