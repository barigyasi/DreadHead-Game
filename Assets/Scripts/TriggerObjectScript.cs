using UnityEngine;

public class TriggerObjectScript : MonoBehaviour
{
    public GameObject[] objectsToActivate; // The objects to activate when triggered
    public Collider triggerCollider; // The trigger collider to activate

    private bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isActive && other.CompareTag("Player"))
        {
            // Activate game objects when the player enters the trigger
            foreach (GameObject obj in objectsToActivate)
            {
                if (obj != null)
                {
                    obj.SetActive(true);
                }
            }

            // Activate the trigger collider
            if (triggerCollider != null)
            {
                triggerCollider.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Deactivate game objects when the player leaves the trigger
            foreach (GameObject obj in objectsToActivate)
            {
                if (obj != null)
                {
                    obj.SetActive(false);
                }
            }

            // Deactivate the trigger collider
            if (triggerCollider != null)
            {
                triggerCollider.enabled = false;
            }
        }
    }

    public void SetActive(bool active)
    {
        isActive = active;
    }
}
