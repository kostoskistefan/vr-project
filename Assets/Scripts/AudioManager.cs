using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<GameObject> instruments;
    public static int latestTimeSample;
    public static int maxSamples;

    void OnEnable()
    {
        latestTimeSample = 0;
        maxSamples = instruments[0].GetComponent<AudioSource>().clip.samples;
    } 

    void Update()
    {
        GetLatestTimeSample();

        foreach (GameObject instrument in instruments)
        {
            AudioSource audio = instrument.GetComponent<AudioSource>();
            
            audio.timeSamples = latestTimeSample;

            if (latestTimeSample >= maxSamples - 1)
            {
                audio.timeSamples = 0;
                audio.Stop();
            }
        }
    }

    private void GetLatestTimeSample()
    {
        foreach (GameObject instrument in instruments)
        {
            AudioSource audio = instrument.GetComponent<AudioSource>();

            if (audio.timeSamples > latestTimeSample)
                latestTimeSample = audio.timeSamples;
        }

        if (latestTimeSample >= maxSamples)
            latestTimeSample = maxSamples - 1;
    }

    public void PlayInstrument(GameObject instrument)
    {
        AudioSource audio = instrument.GetComponent<AudioSource>();

        if (!audio.isPlaying)
            audio.Play();
        
        else audio.Stop();
    }
}