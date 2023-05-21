using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * ResetAll.cs is a script that disables all notes in each instrument in the instruments array when a button is clicked.
 *
 * To use this script, follow these steps:
 * 1. Attach the ResetAll.cs script to the GameObject that represents the button.
 * 2. Connect the MusicButtons scripts of the instruments to the instruments array in the inspector.
 * 3. Implement the OnButtonClick method to define the behavior when the button is clicked.
 *    - Iterate through each instrument in the instruments array.
 *    - Iterate through each note in the current instrument's notes array.
 *    - Set each note to false, disabling it.
 * 4. Run the game, and clicking the button will disable all notes in each instrument in the instruments array.
 */

public class ResetAll : MonoBehaviour
{
    public MusicButtons[] instruments; // Array of MusicButtons objects
    
    public void OnButtonClick()
    {
        for (int i = 0; i <= instruments.Length - 1; i++)
        {
            for (int j = 0; j <= instruments[i].notes.Length - 1; j++)
            {
                instruments[i].notes[j] = false; // Set notes false
            }
        }
    }
}
