using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour
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
