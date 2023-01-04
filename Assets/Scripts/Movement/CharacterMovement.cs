using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    private Rigidbody _rigidbody;

    void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction, float speed) {
        _rigidbody.MovePosition(_rigidbody.position + (direction.normalized * speed * Time.deltaTime));
    }

    public void Rotate(Vector3 direction) {
        Quaternion newRotation = Quaternion.LookRotation(direction);
        _rigidbody.MoveRotation(newRotation);
    }
    public void FallAfterDeath() {
        //_rigidbody.constraints = RigidbodyConstraints.None; //desabilita todas as restrições
        //_rigidbody.isKinematic = false;
        _rigidbody.velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
    }
    public void SmoothRotation(Vector3 direction) {
        var speed = 20;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, speed * Time.deltaTime, 0.0f);
        Quaternion newRotation = Quaternion.LookRotation(direction);
        _rigidbody.MoveRotation(newRotation);
    }

}
