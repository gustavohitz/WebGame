using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour{

    public int startLife = 100;
    
    [HideInInspector]
    public int life;
    public float speed = 5f;

    void Awake() {
        life = startLife;
    }
    
}
