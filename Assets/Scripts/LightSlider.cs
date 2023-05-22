using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
 * LightSlider.cs is a script that allows you to control the intensity of lights using a slider.
 * 
 * To use this script, follow these steps:
 * 1. Attach the LightSlider.cs script to a GameObject in the scene.
 * 2. Create an array of GameObjects representing the lights you want to control.
 * 3. Connect the GameObjects to the lights array in the LightSlider script.
 * 4. Create a Slider UI element in your scene to control the light intensity.
 * 5. Connect the Slider component to the lightSlider variable in the LightSlider script.
 * 6. Run the game, and you will be able to adjust the light intensity using the slider.
 * 
 * Note: Ensure that the lights in the lights array have a Light component attached for intensity control.
 */

public class LightSlider : MonoBehaviour
{
    public GameObject[] lights; // Array of GameObjects representing the lights
    public Slider lightSlider; // Reference to the Slider component controlling the light level
    public float lightLevel; // The current light level value

    // Method called when the light slider value changes
    public void OnLightChanged()
    {
        lightLevel = lightSlider.value; // Update the light level with the new value from the slider
        for (int i = 0; i <= lights.Length - 1; i++)
        {
            lights[i].GetComponent<Light>().intensity = lightLevel; // Adjust the intensity of each light to match the new light level
        }
    }
}