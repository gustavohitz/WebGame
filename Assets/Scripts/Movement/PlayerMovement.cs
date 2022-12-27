using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement {

    public void PlayerRotation(LayerMask groundMask) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        RaycastHit impact;

        if(Physics.Raycast(ray, out impact, 100, groundMask)) {
            Vector3 aimingPosition = impact.point - transform.position;

            aimingPosition.y = transform.position.y;

            Rotate(aimingPosition);
        }
    }
 
}
