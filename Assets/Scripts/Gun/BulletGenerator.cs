using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour {
    public GameObject bullet;
    public GameObject bulletPosition;
    public AudioClip bulletSFX;

    void Update() {
        Shoot();
    }
    void Shoot() {
        if(Input.GetButtonDown("Fire1")) {
            Instantiate(bullet, bulletPosition.transform.position, bulletPosition.transform.rotation);
            AudioManager.instance.PlayOneShot(bulletSFX);
        }
    }    
}
