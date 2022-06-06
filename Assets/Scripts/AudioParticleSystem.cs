using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioParticleSystem : MonoBehaviour
{
    private AudioSource audioSource;
    private ParticleSystem particleSystemObject;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        particleSystemObject = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (audioSource.isPlaying)
            particleSystemObject.Play();

        else particleSystemObject.Stop();
    }
}
