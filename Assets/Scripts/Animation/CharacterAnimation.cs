using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    private Animator _characterAnimator;

    void Awake() {
        _characterAnimator = GetComponent<Animator>();
    }

    public void AttackAnimation(bool state) {
        _characterAnimator.SetBool("Attacking", state);
    }

    public void RunningAnimation(float movingValue) {
        _characterAnimator.SetFloat("Running", movingValue);
    }

    public void DeathAnimation() {
        _characterAnimator.SetTrigger("Death");
    }
   
}
