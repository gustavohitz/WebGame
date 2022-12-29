using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKitBase : MonoBehaviour {

    private int _cureAmount = 15; 

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            other.GetComponent<PlayerController>().Cure(_cureAmount);
            Destroy(gameObject);
        }
    }
 
}
