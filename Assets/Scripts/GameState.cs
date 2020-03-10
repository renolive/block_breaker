using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
     [Range(0.1f, 10)]
     public float timeScale = 1f;

    void Awake() {
        Time.timeScale = timeScale;
    }
}
