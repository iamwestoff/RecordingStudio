using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * MuteAll.cs is a script that allows muting/unmuting of all instruments at once.
 * 
 * To use this script, follow these steps:
 * 1. Attach the MuteAll.cs script to a GameObject that will trigger the mute/unmute functionality.
 * 2. Create an array of MusicButtons objects by assigning the desired instruments to the 'instruments' array in the Unity Inspector.
 * 3. Implement the OnButtonClick method to define the behavior when the mute button is clicked.
 *    - Scroll down in the inspector and find the On Click () section
 *    - Click the "+" button
 *    - Select the current gameObject
 *    - Click on the NoFunction dropdown and select MusicButtons->OnButtonPressed()
 * 4. Run the game, and clicking the mute button will toggle the mute state of all instruments.
 * 
 * Note: Ensure that the MusicButtons script on each instrument has a 'toggleMute' method implemented to handle mute functionality.
 * 
 * Note: This script can be used as a SOLO button as well, by just changing the instrument array to be everything other than what we want to solo.
 */

public class MuteAll : MonoBehaviour
{
    public MusicButtons[] instruments; // Array of MusicButtons objects
    
    public void OnButtonClick()
    {
        for (int i = 0; i <= instruments.Length - 1; i++)
        {
            instruments[i].toggleMute();
        }
    }
}