using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerTeleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject xrRig;
    public GameObject door;
    public static Boolean finished = false;
    public void Teleport()
    {
        if (!door.CompareTag("RightDoor") || (door.CompareTag("RightDoor") && finished))
        {
                if (xrRig != null && teleportTarget != null)
            {
                Vector3 cameraOffset = xrRig.transform.position - Camera.main.transform.position;

                // Adjust the Y position so the camera ends up at 2.33 height
                Vector3 newPosition = teleportTarget.position + cameraOffset;
                float cameraToRigHeight = Camera.main.transform.position.y - xrRig.transform.position.y;
                newPosition.y = 2.33f - cameraToRigHeight;

                xrRig.transform.position = newPosition;
            }
        }
        
    }

}
