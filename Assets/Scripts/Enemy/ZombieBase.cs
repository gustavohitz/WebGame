using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBase : MonoBehaviour {
    public GameObject player;
    public float speed = 5;
    public float gapBetweenPlayerAndEnemy = 2.5f;
    public string tagToFind = "Player";


    void Start() {
        player = GameObject.FindWithTag(tagToFind);
        int generateZombieType = Random.Range(1, 28); //um a mais do que a quantidade certa
        transform.GetChild(generateZombieType).gameObject.SetActive(true);
    }
    void FixedUpdate() {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        Vector3 direction = player.transform.position - transform.position;

        Quaternion newRotation = Quaternion.LookRotation(direction);
        GetComponent<Rigidbody>().MoveRotation(newRotation);

        if(distance > gapBetweenPlayerAndEnemy) {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direction.normalized * speed * Time.deltaTime));
            GetComponent<Animator>().SetBool("Attacking", false);
        }
        else {
            GetComponent<Animator>().SetBool("Attacking", true);
        }
    }
    
    void EnemyAttack() {
        Time.timeScale = 0;
        player.GetComponent<PlayerController>().gameOver.SetActive(true);
        player.GetComponent<PlayerController>().isAlive = false;
    }
}
