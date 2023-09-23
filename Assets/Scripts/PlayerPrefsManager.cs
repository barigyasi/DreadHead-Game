using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public void ClearPlayerPrefs()
    {
        // Clear PlayerPrefs data
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        // Log a message to the console
        Debug.Log("PlayerPrefs data has been cleared.");
    }
}
