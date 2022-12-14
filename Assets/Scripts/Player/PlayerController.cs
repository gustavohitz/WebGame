using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;

    void Update() {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xAxis, 0, zAxis);

        transform.Translate(direction * speed * Time.deltaTime);

        if(direction != Vector3.zero) {
            GetComponent<Animator>().SetBool("Running", true);
        }
        else {
            GetComponent<Animator>().SetBool("Running", false);
        }
    }

}
