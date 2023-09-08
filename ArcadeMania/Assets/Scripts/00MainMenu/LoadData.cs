using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    GameData gameData;

    [SerializeField] private GameObject[] milestoneObjects; // Existing milestones in the scene
    [SerializeField] private GameObject currentMilestonePrefab;
    [SerializeField] private GameObject milestonePrefab;
    [SerializeField] private GameObject oldMilestonePrefab;


    void Start()
    {
        gameData = new GameData();
        Debug.Log("Highest Round: " + gameData.HighestRound);
        int currentLevel = gameData.HighestRound - 1;

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

    // Update is called once per frame
    void Update()
    {

    }
}
