using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

/*
 * MusicButtons.cs is a script that allows objects to add sound to the timeline when interacted with.
 * 
 * To use this script, follow these steps:
 * 1. Attach the MusicButtons.cs script to the GameObject that you want to create a sound.
 * 2. Add necessary references and configure the public variables in the MusicButtons script:
 *    - Connect the metronome script by assigning the appropriate metronome instance to the _metronome variable.
 *    - Connect the AudioSource component to the audioSource variable.
 *    - Connect the muteLogo component to the muteLogo variable.
 * 3. *OPTIONAL* Implement the OnButtonPressed method to define the behavior when the object is interacted with.
 *    - Scroll down in the inspector and find the On Click () section
 *    - Click the "+" button
 *    - Select the current gameObject
 *    - Click on the NoFunction dropdown and select MusicButtons->OnButtonPressed()
 * 4. Run the game, and the objects with the MusicButtons script will generate sound based on the configured notes.
 * 
 * Note: Ensure that you have the necessary audio clips assigned to the AudioSource component for desired sounds.
 */

public class MusicButtons : MonoBehaviour
{
    public const int maxMeasures = 16; // The maximum number of measures
    public bool[] notes = new bool[maxMeasures * 16]; // Array of bools representing notes
    public metronome _metronome; // Reference to the metronome script
    public AudioSource audioSource; // Reference to the AudioSource component
    public bool muted = false;
    public GameObject muteLogo;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < notes.Length; i++)
        {
            notes[i] = false; // Initialize all notes to false
        }
    }

    public void OnButtonPressed()
    {
        notes[_metronome.currentNote - 1] = true; // Toggle the note to true at the currentNote
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DrumStick"))
        {
            notes[_metronome.currentNote - 1] = true; // Toggle the note to true at the currentNote
        }
    }

    public void toggleMute()
    {
        if (muted)
        {
            muted = false;
            muteLogo.SetActive(false); // Turn muted logo off
        }
        else
        {
            muted = true;
            muteLogo.SetActive(true); // Turn muted logo on
        }
    }

    public void playSound()
    {
        if (!muted)
        {
            if (notes[_metronome.currentNote - 1])
            {
                audioSource.Play(); // Play the sound if the note is set to true
            }
        }
    }
}