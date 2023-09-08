using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{


    [SerializeField] private GameObject[] milestoneObjects; // Existing milestones in the scene
    [SerializeField] private GameObject currentMilestonePrefab;
    [SerializeField] private GameObject milestonePrefab;
    [SerializeField] private GameObject oldMilestonePrefab;
    [SerializeField] private TMPro.TextMeshProUGUI introText;

    void Start()
    {

        Debug.Log("LoadData Start - " + GameData.StatusMessage + " - " + GameData.HighestRound + " - " + GameData.LoadingStatus);
        introText.text = GameData.StatusMessage;

        int currentLevel = GameData.HighestRound - 1;

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
        // Listen for "Enter" key press
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Load the scene at index gameData.HighestRound
            SceneManager.LoadScene(GameData.HighestRound);
        }
    }
}
