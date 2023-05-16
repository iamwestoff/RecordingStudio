using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIposition : MonoBehaviour
{
    public GameObject cam;
    public Vector3 offset = new Vector3(-0.5f, -0.3f, 0f);
    
    private void Start()
    {
        
    }
    
    private void Update()
    {
        // Get the position of the target object
        Vector3 cameraPosition = cam.transform.position;
        
        // Apply the offset to the camera position
        Vector3 targetPosition = cameraPosition + offset;
            
        // Preserve the current rotation of the game object
        Quaternion currentRotation = transform.rotation;
    
        // Set the current game object's position to match the target position
        transform.position = targetPosition;
            
        // Restore the original rotation
        transform.rotation = currentRotation;
    }
}
