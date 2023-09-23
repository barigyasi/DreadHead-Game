using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class WalletRevealScript : MonoBehaviour
{
    [Header("Settings")]
    public GameObject targetObject; // Reference to the GameObject you want to show/hide
    public bool initiallyHidden = true; // Determines if the targetObject is initially hidden

    [Header("Button")]
    public Button button; // Reference to the UI Button component

    [Header("Events")]
    public UnityEvent onEnableTargetObject; // UnityEvent to trigger when enabling the targetObject

    private void Start()
    {
        // Initialize the targetObject's visibility based on the initiallyHidden flag
        if (targetObject != null)
        {
            targetObject.SetActive(initiallyHidden);
        }
        else
        {
            Debug.LogWarning("Target GameObject is not assigned in the inspector.");
        }

        // Attach the custom function to the button's onClick event
        if (button != null)
        {
            button.onClick.AddListener(EnableTargetObject);
        }
        else
        {
            Debug.LogWarning("Button component not found on the GameObject.");
        }
    }

    private void EnableTargetObject()
    {
        if (targetObject != null && !targetObject.activeSelf)
        {
            // Enable the targetObject
            targetObject.SetActive(true);

            // Trigger the UnityEvent for enabling the targetObject
            onEnableTargetObject.Invoke();
        }
    }
}
