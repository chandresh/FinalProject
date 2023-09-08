using UnityEngine;

public class MilestoneManager : MonoBehaviour
{
    [SerializeField] private GameObject[] milestoneObjects; // Existing milestones in the scene
    [SerializeField] private GameObject currentMilestonePrefab;
    [SerializeField] private GameObject milestonePrefab;
    [SerializeField] private GameObject oldMilestonePrefab;

    private int currentLevel;

    void Start()
    {
        // Load the current level from PlayerPrefs or elsewhere
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);

        // Loop through each milestone and replace based on the current level
        for (int i = 0; i < milestoneObjects.Length; i++)
        {
            GameObject milestoneToInstantiate;

            if (i == currentLevel)
            {
                milestoneToInstantiate = currentMilestonePrefab;
            }
            else if (i < currentLevel)
            {
                milestoneToInstantiate = oldMilestonePrefab;
            }
            else
            {
                milestoneToInstantiate = milestonePrefab;
            }

            // Get the position of the existing milestone
            Vector3 position = milestoneObjects[i].transform.position;

            // Destroy the existing milestone
            Destroy(milestoneObjects[i]);

            // Instantiate the new milestone at the old position
            milestoneObjects[i] = Instantiate(milestoneToInstantiate, position, Quaternion.identity);
        }
    }
}
