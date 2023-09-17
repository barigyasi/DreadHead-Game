using UnityEngine;
using MoreMountains.TopDownEngine;

public class ActivateObjectsOnCollect : MonoBehaviour
{
    [Header("Activation Settings")]
    public int itemRequiredPoints = 1; // Points required to reveal itemToActivate
    public int otherObjectRequiredPoints = 2; // Points required to activate otherObjectToActivate

    [Header("Objects to Activate")]
    public GameObject itemToActivate; // The item to reveal when enough points are collected
    public GameObject otherObjectToActivate; // The trigger object for activation

    private bool objectsActivated = false;

    private void Update()
    {
        // Check if the required points for itemToActivate have been reached
        if (GameManager.Instance.Points >= itemRequiredPoints && itemToActivate != null)
        {
            // Reveal itemToActivate
            itemToActivate.SetActive(true);
        }

        // Check if the required points for otherObjectToActivate have been reached
        if (GameManager.Instance.Points >= otherObjectRequiredPoints && otherObjectToActivate != null)
        {
            // Activate otherObjectToActivate (if it's a trigger)
            otherObjectToActivate.SetActive(true);
        }

        objectsActivated = true; // Mark objects as activated
    }
}
