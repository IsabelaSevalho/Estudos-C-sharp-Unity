using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip getItemSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
    }

    public void PlayGetItem()
    {
        audioSource.PlayOneShot(getItemSound);//PlayOneShot toca apenas uma vez, recebe um audioclip
    }
}
