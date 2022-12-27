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

}
