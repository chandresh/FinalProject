using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestData : MonoBehaviour
{
    void Start()
    {
        // Test GameData
        Debug.Log("Highest Round: " + GameData.HighestRound);
        Debug.Log("Money: " + GameData.Money);
        Debug.Log("Highest Score: " + GameData.HighestScore);
        Debug.Log("Status Message: " + GameData.StatusMessage);
    }

}
