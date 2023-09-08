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

        // Deactivate highlight for all TextManager objects
        foreach (GameObject text in levelTexts)
        {
            TextManager tm = text.GetComponent<TextManager>();
            if (tm != null)
            {
                tm.isHighlighted = false;
            }
        }

        // Activate highlight for the highest round
        TextManager currentTM = levelTexts[currentLevel].GetComponent<TextManager>();
        currentTM.isHighlighted = true;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
