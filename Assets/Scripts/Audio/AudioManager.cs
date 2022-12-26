using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour{

    public static AudioSource instance;
    private AudioSource _audioSource;


    void Awake() {
        _audioSource = GetComponent<AudioSource>();
        instance = _audioSource;
    }        

}
