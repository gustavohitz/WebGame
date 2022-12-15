using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;
    public float timeToDestroy = 3f;
    public string tagToCheck = "Enemy";
    
    void FixedUpdate() {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * speed * Time.deltaTime);
        Destroy(gameObject, timeToDestroy);
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == tagToCheck) {
            Destroy(other.gameObject);
        }
        
        Destroy(gameObject);
    }

}