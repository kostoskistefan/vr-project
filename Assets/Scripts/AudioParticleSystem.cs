using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioParticleSystem : MonoBehaviour
{
    public void ToggleParticleSystem()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        ParticleSystem particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();

        if (audio.isPlaying)
            particleSystem.Play();

        else particleSystem.Stop();
    }
}
