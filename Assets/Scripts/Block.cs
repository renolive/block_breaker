using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public AudioClip audioClip;
    public LevelState level;

    void Start() {
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        DestroyBlock();
    }

    void DestroyBlock() {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        level.DestroyBlock();
        Destroy(gameObject);
    }
}
