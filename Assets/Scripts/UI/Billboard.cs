using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

    void Update() {
        LookAtCamera();
    }

    void LookAtCamera() {
        transform.LookAt(transform.position - Camera.main.transform.forward);
    }

}
