using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<GameObject> instruments;

    void Update()
    {
        int lastTimeSamples = GetLatestTimeSamples();

        foreach (GameObject instrument in instruments)
        {
            AudioSource audio = instrument.GetComponent<AudioSource>();
            
            audio.timeSamples = lastTimeSamples;
        }
    }

    private int GetLatestTimeSamples()
    {
        int lastTimeSamples = 0;

        foreach (GameObject instrument in instruments)
        {
            AudioSource audio = instrument.GetComponent<AudioSource>();

            if (audio.timeSamples > lastTimeSamples)
                lastTimeSamples = audio.timeSamples;
        }

        return lastTimeSamples;
    }

    public void PlayInstrument(GameObject instrument)
    {
        AudioSource audio = instrument.GetComponent<AudioSource>();

        if (!audio.isPlaying)
            audio.Play();
        
        else audio.Stop();
    }
}