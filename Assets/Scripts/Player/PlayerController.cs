using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    Vector3 direction;

    void Update() {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        direction = new Vector3(xAxis, 0, zAxis);

        if(direction != Vector3.zero) {
            GetComponent<Animator>().SetBool("Running", true);
        }
        else {
            GetComponent<Animator>().SetBool("Running", false);
        }
    }
    void FixedUpdate() {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direction * speed * Time.deltaTime));
    }

}
