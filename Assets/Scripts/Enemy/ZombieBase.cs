using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBase : MonoBehaviour {
    public GameObject player;
    public float speed = 5;
    public float gapBetweenPlayerAndEnemy = 2.5f;
    void FixedUpdate() {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        //o colisor do player e do inimigo valem 1, logo a distancia é 2
        if(distance > gapBetweenPlayerAndEnemy) {
            Vector3 direction = player.transform.position - transform.position;

            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direction.normalized * speed * Time.deltaTime));

            Quaternion newRotation = Quaternion.LookRotation(direction);
            GetComponent<Rigidbody>().MoveRotation(newRotation);
        }
    }
}
