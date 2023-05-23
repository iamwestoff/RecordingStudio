using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstrumentDrums : MonoBehaviour
{ 
    [SerializeField] public AudioClip instrumentAudio;  // Sound to play when triggered

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DrumStick"))
        {
            AudioSource.PlayClipAtPoint(instrumentAudio, transform.position);
        }
    }
}
