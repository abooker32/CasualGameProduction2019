using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTempo : MonoBehaviour
{
    void Start()
    {
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.onBeat.AddListener(onOnbeatDetected);
        processor.onSpectrum.AddListener(onSpectrum);
    }
    void onOnbeatDetected()
    {
        Debug.Log("Beat!!!");
    }
    void onSpectrum(float[] spectrum)
    {
        for (int i = 0; i < spectrum.Length; ++i)
        {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i], 0);
            Debug.DrawLine(start, end);
        }
    }
}
