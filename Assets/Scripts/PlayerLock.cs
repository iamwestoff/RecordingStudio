using UnityEngine;

public class VRInteractableObject : MonoBehaviour
{
    public OVRInput.Button lockButton;      // Button to lock the player's position
    public OVRInput.Button unlockButton;    // Button to unlock the player's position
    public Transform lockedPosition;        // Locked position for the player
    private bool _isPlayerLocked;    // Flag to track player lock state
    private Vector3 _playerPositionBeforeLock;   // Store player's position before lock

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        if (!other.CompareTag("Player") || _isPlayerLocked) return;
        // Lock the player's position
        if (!OVRInput.GetDown(lockButton)) return;
        _isPlayerLocked = true;
        _playerPositionBeforeLock = other.transform.position;
        other.GetComponent<Rigidbody>().isKinematic = true;
        other.transform.position = lockedPosition.position;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited");
        if (!other.CompareTag("Player") || !_isPlayerLocked) return;
        // Unlock the player's position
        if (!OVRInput.GetDown(unlockButton)) return;
        _isPlayerLocked = false;
        other.GetComponent<Rigidbody>().isKinematic = false;
        other.transform.position = _playerPositionBeforeLock;
    }
}