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

    private void OnMouseDown()
    {
        if (!isActivated)
        {
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

            isActivated = true;

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
