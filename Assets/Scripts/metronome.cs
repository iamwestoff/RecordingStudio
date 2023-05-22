using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * metronome.cs is a script that keeps track of time as the BPM changes and updates the current note being played.
 *
 * To use this script, follow these steps:
 * 1. Attach the metronome.cs script to a GameObject that represents the metronome.
 * 2. Connect the necessary components and variables in the inspector:
 *    - Connect the Slider component for controlling the BPM to the bpmSlider variable.
 *    - Connect the Slider component for controlling the number of measures to the measuresSlider variable.
 *    - Connect the AudioSource component to the audioSource variable.
 *    - Connect the TMP_Text component to the textObj variable.
 *    - Connect the MusicButtons scripts of the instruments to the instruments array in the inspector.
 * 3. Run the game, and the metronome will keep track of time, play the beat sound, update the current note, and allow you to play additional sounds based on the BPM and measures.
 *
 * Note: In order to accommodate 2 notes per beat (8th notes), the BPM value is doubled.
 * This ensures that the timing of the notes aligns correctly with the desired subdivision.
 * For example, if the original BPM is set to 120, doubling it to 240 allows for each beat
 * to be divided into two equal parts, enabling the playback of 8th notes.
 */

public class metronome : MonoBehaviour
{
    public float bpm = 60f; // Beats per minute
    public Slider bpmSlider; // Slider to control the BPM
    public Slider measuresSlider; // Slider to control the number of measures
    public AudioSource audioSource; // Reference to the AudioSource component
    public TMP_Text currentNoteText; // Reference to the TMP_Text component to display the current note
    public TMP_Text currentMeasureText; // Reference to the TMP_Text component to display the current measure
    public int currentNote = 1; // The current note being played
    public int currentMeasure = 1; // The current measure being played
    private int measures = 1; // The total number of measures
    public MusicButtons[] instruments; // Array of MusicButtons objects

    private double nextBeatTime; // The time when the next beat should be played

    void Start()
    {
        bpm = bpmSlider.value * 4; // Set the initial BPM from the slider
        nextBeatTime = AudioSettings.dspTime; // Initialize the next beat time
        bpmSlider.onValueChanged.AddListener(delegate
        {
            OnBpmChanged();
        }); // Add a listener for the BPM slider value change
    }

    void Update()
    {
        if (AudioSettings.dspTime >= nextBeatTime)
        {
            PlayBeat(); // Play the beat
            PlaySounds(); // Play additional sounds
            nextBeatTime += 60.0 / bpm; // Calculate the time for the next beat based on the BPM
        }
    }

    void PlayBeat()
    {
        float currentNoteTemp;

        currentNote++;

        // Check if the current note exceeds the maximum number of notes in the timeline
        if (currentNote > measuresSlider.value * 16)
        {
            currentNote = 1; // Reset the current note to the first note
        }

        // Calculate the new value for currentNoteTemp based on currentNote
        currentNoteTemp = ((currentNote - 1) % 16) + 1;
        currentNoteTemp = Mathf.CeilToInt(currentNoteTemp / 4);

        currentNoteText.text = "Current Note: " + currentNoteTemp + "/" + 4; // Update the text to display the current note

        currentMeasure = Mathf.FloorToInt(currentNote / 16) + 1; // Update the current measure

        // Check if the current measure exceeds the total number of measures
        if (currentMeasure > measuresSlider.value)
        {
            currentMeasure = 1; // Reset the current measure to the first measure
        }

        currentMeasureText.text =
            "Measure: " + currentMeasure + "/" + measuresSlider.value; // Update the text to display the current measure

        // Check if the currentNote is an even number since there are 8 notes per measure rather than 4
        if (currentNote % 16 == 0)
        {
            audioSource.pitch = 4; // Set the pitch of the audio source to 4
            audioSource.Play(); // Play the beat sound
        }
        else if (currentNote % 4 == 0)
        {
            audioSource.pitch = 2; // Set the pitch of the audio source to 2
            audioSource.Play(); // Play the beat sound
        }
    }

    public void OnBpmChanged()
    {
        bpm = bpmSlider.value * 4; // Update the BPM from the slider value
        nextBeatTime = AudioSettings.dspTime; // Reset the next beat time
    }

    void PlaySounds()
    {
        for (int i = 0; i < instruments.Length; i++)
        {
            instruments[i].playSound();
        }
    }
}