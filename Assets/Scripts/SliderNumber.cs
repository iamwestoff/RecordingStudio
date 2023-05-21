using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/*
 * SliderNumber.cs is a script that updates the text displayed as the slider's value changes.
 *
 * To use this script, follow these steps:
 * 1. Attach the SliderNumber.cs script to the GameObject that contains the slider and text objects.
 * 2. Connect the TMP_Text component to the textObj variable in the inspector.
 * 3. Connect the Slider component to the slider variable in the inspector.
 * 4. Set the initialValue to the desired initial value of the slider.
 * 5. Set the min value and max value in the inspector.
 * 6. Enable whole numbers in the inspector.
 * 5. Run the game, and the text will display the current value of the slider.
 */

public class SliderNumber : MonoBehaviour
{
    public TMP_Text textObj; // Reference to the TMP_Text component to display the slider value
    public Slider slider; // Reference to the Slider component to get the value
    public int initialValue; // The initial value of the slider
    private int sliderNum; // The integer value of the slider

    // Start is called before the first frame update
    void Start()
    {
        textObj.text = initialValue.ToString(); // Set the initial text value to the initial slider value
    }

    // Update is called once per frame
    void Update()
    {
        sliderNum = (int)slider.value; // Get the integer value of the slider
        textObj.text = sliderNum.ToString(); // Update the text value to display the current slider value
    }
}