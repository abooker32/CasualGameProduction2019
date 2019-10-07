using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmHandler : MonoBehaviour
{
    public float bpm;
    public float[] notes;
    public AudioClip[] noteSounds;
    public int nextIndex = 0;
    public float songPosition;
    public float songPosInBeats;
    public float secPerBeat;
    public float dsptimesong;
    public AudioSource backgroundTrack;
    public AudioSource mainInstrumentTrack;
    public GameObject noteOBJ;
    private float beatsShownInAdvance = 1;

    void Start()
    {
        int songLength = (int)backgroundTrack.clip.length / 2;

        notes = new float[songLength];
        for (int i = 0; i < notes.Length; i++)
        {
            notes[i] = i * 4;
        }

        secPerBeat = 60f / bpm;
        dsptimesong = (float)AudioSettings.dspTime;
        backgroundTrack.Play();
    }

    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dsptimesong);
        songPosInBeats = songPosition / secPerBeat;
        if (nextIndex < notes.Length && notes[nextIndex] < songPosInBeats + beatsShownInAdvance)
        {
            Instantiate(noteOBJ, new Vector3(Random.Range(-8, 8), Random.Range(1, 8)), Quaternion.identity);
            nextIndex++;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(songPosition > notes[nextIndex - 1] && songPosition < notes[nextIndex])
            {
                mainInstrumentTrack.clip = noteSounds[Mathf.RoundToInt(nextIndex / 4)];
                mainInstrumentTrack.Play();
            }
        }
    }
}