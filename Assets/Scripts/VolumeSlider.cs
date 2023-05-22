using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
 * VolumeSlider.cs is a script that allows for adjusting the volume of a group of instruments.
 * 
 * To use this script, follow these steps:
 * 1. Attach the VolumeSlider.cs script to a GameObject that will control the volume.
 * 2. Add necessary references and configure the public variables in the VolumeSlider script:
 *    - Connect the Slider component by assigning the appropriate Slider instance to the volumeSlider variable.
 *    - Set the initial volume value by modifying the volume variable.
 *    - Connect the MusicButtons objects by assigning them to the instruments array.
 * 3. Set up the UI Slider component:
 *    - Attach the VolumeSlider.OnVolumeChanged method as a listener to the OnValueChanged event of the Slider component.
 * 4. Run the game, and adjusting the volume slider will update the volume of all instruments in the instruments array.
 * 
 * Note: Ensure that the MusicButtons objects have an AudioSource component to control their volume.
 */

public class VolumeSlider : MonoBehaviour
{
    public MusicButtons[] instruments; // Array of MusicButtons objects
    public Slider volumeSlider;
    public float volume;

    // Method called when the volume slider value changes
    public void OnVolumeChanged()
    {
        volume = volumeSlider.value / 100; // Convert the slider value to a percentage
        for (int i = 0; i <= instruments.Length - 1; i++)
        {
            instruments[i].audioSource.volume = volume; // Update the volume of each instrument's audio source
        }
    }
}