using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    public LayerMask groundMask;
    Vector3 direction;

    void Update() {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        direction = new Vector3(xAxis, 0, zAxis);

        if(direction != Vector3.zero) {
            GetComponent<Animator>().SetBool("Running", true);
        }
        else {
            GetComponent<Animator>().SetBool("Running", false);
        }
    }
    void FixedUpdate() {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direction * speed * Time.deltaTime));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        RaycastHit impact;

        if(Physics.Raycast(ray, out impact, 100, groundMask)) {
            Vector3 aimingPosition = impact.point - transform.position;

            aimingPosition.y = transform.position.y;

            Quaternion newRotation = Quaternion.LookRotation(aimingPosition);

            GetComponent<Rigidbody>().MoveRotation(newRotation);
        }
    }

}
