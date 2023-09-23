using UnityEngine;
using System.Collections;
using MoreMountains.Tools;

namespace MoreMountains.TopDownEngine
{
    /// <summary>
    /// Coin manager
    /// </summary>
    [AddComponentMenu("TopDown Engine/Items/Coin")]
    public class Coin : PickableItem
    {
        /// The amount of points to add when collected
        [Tooltip("The amount of points to add when collected")]
        public int PointsToAdd = 10;

        // A unique identifier for this coin (you may want to set this in the Inspector)
        public string CoinID = "Coin";

        // A flag to check if the coin has already been collected
        private bool isCollected = false;

        private void Start()
        {
            // Check if the coin has been collected before
            if (PlayerPrefs.HasKey(CoinID))
            {
                isCollected = PlayerPrefs.GetInt(CoinID) == 1;
                if (isCollected)
                {
                    // If the coin has been collected, disable it
                    gameObject.SetActive(false);
                }
            }
        }

        /// <summary>
        /// Triggered when something collides with the coin
        /// </summary>
        /// <param name="picker">The GameObject that picked up the coin.</param>
        protected override void Pick(GameObject picker)
        {
            if (!isCollected)
            {
                // Add points when collected for the first time
                TopDownEnginePointEvent.Trigger(PointsMethods.Add, PointsToAdd);

                // Set the collected flag to true
                isCollected = true;

                // Save the collected state in PlayerPrefs
                PlayerPrefs.SetInt(CoinID, 1);
                PlayerPrefs.Save();

                // Disable the coin
                gameObject.SetActive(false);
            }
        }
    }
}
