using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    void Update() {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xAxis, 0, zAxis);

        transform.Translate(direction);
    }

}
