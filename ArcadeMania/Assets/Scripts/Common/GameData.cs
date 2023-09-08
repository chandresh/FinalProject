using UnityEngine;

public class GameData
{
    public int HighestRound { get; private set; }
    public int HighestScore { get; private set; }

    public GameData()
    {
        HighestRound = PlayerPrefs.GetInt("HighestRound", 0);
        HighestScore = PlayerPrefs.GetInt("HighestScore", 0);
    }

    public void UpdateHighestRound(int newRound)
    {
        if (newRound > HighestRound)
        {
            HighestRound = newRound;
        }
    }

    public void UpdateHighestScore(int newScore)
    {
        if (newScore > HighestScore)
        {
            HighestScore = newScore;
        }
    }

    public void SaveData()
    {
        // Save data back to PlayerPrefs
        PlayerPrefs.SetInt("HighestRound", HighestRound);
        PlayerPrefs.SetInt("HighestScore", HighestScore);
        PlayerPrefs.Save();
    }
}
