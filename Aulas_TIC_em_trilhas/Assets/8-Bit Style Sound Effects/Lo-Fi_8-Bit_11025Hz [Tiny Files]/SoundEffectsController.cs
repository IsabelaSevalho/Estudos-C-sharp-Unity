using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip enemyDeathSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayEnemyDeath()
    { 
        audioSource.PlayOneShot(enemyDeathSound);
    }
}
