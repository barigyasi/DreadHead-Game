using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitionButton : MonoBehaviour
{
    public string nextSceneName; // The name of the next scene
    
    [SerializeField] private Button button; // Reference to the UI Button

    private void Start()
    {
        // Attach a click event handler to the button
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogWarning("Button reference is not assigned in the inspector.");
        }
    }

    private void OnButtonClick()
    {
        // Load the next scene when the button is clicked
        SceneManager.LoadScene("Home");
    }
}
