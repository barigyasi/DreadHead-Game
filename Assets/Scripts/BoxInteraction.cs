using UnityEngine;
using UnityEngine.UI;

public class BoxInteraction : MonoBehaviour
{
    public GameObject untappedBox;
    public GameObject objectToActivate;
    public Text clickText; // Reference to the UI Text
    public GameObject oldDialogueArea; // Reference to the old dialogue area
    public GameObject newDialogueArea; // Reference to the new dialogue area

    private bool isActivated = false;
    private string PlayerPrefsKey = "BoxState";

    private void Start()
    {
        // Load the box state from PlayerPrefs when the scene starts
        if (PlayerPrefs.HasKey(PlayerPrefsKey))
        {
            isActivated = PlayerPrefs.GetInt(PlayerPrefsKey) == 1;
        }

        // Set the initial state of the boxes based on the loaded value
        if (isActivated)
        {
            gameObject.SetActive(false);
            if (untappedBox != null)
            {
                untappedBox.SetActive(true);
            }
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
            if (oldDialogueArea != null)
            {
                oldDialogueArea.SetActive(false);
            }
            if (newDialogueArea != null)
            {
                newDialogueArea.SetActive(true);
            }
            if (clickText != null)
            {
                clickText.gameObject.SetActive(false);
            }
        }
    }

    private void OnMouseDown()
    {
        if (!isActivated)
        {
            // Save the box state to PlayerPrefs
            PlayerPrefs.SetInt(PlayerPrefsKey, 1);
            PlayerPrefs.Save();

            // Update the state of the boxes
            isActivated = true;

            // Hide the tapped box
            gameObject.SetActive(false);

            // Show the untapped box if it's assigned
            if (untappedBox != null)
            {
                untappedBox.SetActive(true);
            }

            // Activate the object if it's assigned
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }

            // Deactivate the old dialogue area if it's assigned
            if (oldDialogueArea != null)
            {
                oldDialogueArea.SetActive(false);
            }

            // Activate the new dialogue area if it's assigned
            if (newDialogueArea != null)
            {
                newDialogueArea.SetActive(true);
            }

            // Hide the UI Text
            if (clickText != null)
            {
                clickText.gameObject.SetActive(false);
            }
        }
    }

    private void OnMouseOver()
    {
        // Display the UI Text when the mouse is over the box
        if (!isActivated && clickText != null)
        {
            clickText.gameObject.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        // Hide the UI Text when the mouse exits the box
        if (!isActivated && clickText != null)
        {
            clickText.gameObject.SetActive(false);
        }
    }
}
