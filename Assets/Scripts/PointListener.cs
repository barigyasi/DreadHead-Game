using UnityEngine;
using MoreMountains.TopDownEngine;

public class Pointlistener : MonoBehaviour
{
    [Header("Activation Settings")]
    public int requiredPoints = 15; // Points required to activate the objects

    [Header("Objects to Activate")]
    public GameObject objectToActivate; // The object to activate when enough points are collected

    private bool objectsActivated = false;

    private void Update()
    {
        // Check if the required points have been reached and the objects haven't been activated yet
        if (GameManager.Instance.Points >= requiredPoints && objectToActivate != null && !objectsActivated)
        {
            // Activate the object
            objectToActivate.SetActive(true);
            objectsActivated = true; // Mark the object as activated
        }
    }
}
