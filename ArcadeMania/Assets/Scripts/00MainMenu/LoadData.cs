using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    GameData gameData;
    [SerializeField] private GameObject[] levelTexts;

    void Start()
    {
        gameData = new GameData();
        Debug.Log("Highest Round: " + gameData.HighestRound);
        int currentLevel = gameData.HighestRound;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
