using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    
    private Vector3 _distance;

    void Start() {
        _distance = transform.position - player.transform.position;
    }

    void Update() {
        transform.position = player.transform.position + _distance;
    }
    
}
