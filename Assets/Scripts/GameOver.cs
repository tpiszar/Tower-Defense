using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!Manager.gameOver)
        {
            Music.playLoss = true;
            Manager.gameOver = true;
        }

    }
}
