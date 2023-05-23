using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectionVisualizerToggle : MonoBehaviour
{
    public GameObject visualizer; 
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UIArea"))
        {
            visualizer.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UIArea"))
        {
            visualizer.SetActive(false);
        }
    }
}
