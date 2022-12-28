using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable { //quem for morrer precisa ter quais métodos?
    void TakeDamage(int damage); //temos apenas que declarar o método

    void Death(); //todos que forem passíveis de morrer terão esses dois métodos

    void GameOver();
}
