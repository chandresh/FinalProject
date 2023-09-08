using UnityEngine;


public enum GameLoadingStatus
{
    NewGame,
    Lost,
    Won
}


public static class GameData
{
    public static int HighestRound { get; private set; }
    public static int HighestScore { get; private set; }
    public static string StatusMessage { get; private set; }
    public static GameLoadingStatus LoadingStatus { get; set; }

    static GameData()
    {
        HighestRound = PlayerPrefs.GetInt("HighestRound", 1);
        HighestScore = PlayerPrefs.GetInt("HighestScore", 0);
        SetStatusMessage();
        LoadingStatus = GameLoadingStatus.NewGame;  // Default status
    }

    private static void SetStatusMessage()
    {
        switch (HighestRound)
        {
            case 1:
                if (LoadingStatus == GameLoadingStatus.NewGame)
                {
                    StatusMessage = "Welcome! You start in New Delhi.";
                }
                else
                {
                    StatusMessage = "You lost! Try Level 1 again.";
                }
                break;
            case 2:
                if (LoadingStatus == GameLoadingStatus.NewGame)
                {
                    StatusMessage = "Welcome Back! You were last in Agra.";
                }
                else if (LoadingStatus == GameLoadingStatus.Won)
                {
                    StatusMessage = "Great job! Next you go to Agra!";
                }
                else
                {
                    StatusMessage = "So close! Try Agra again.";
                }
                break;
            case 3:
                if (LoadingStatus == GameLoadingStatus.NewGame)
                {
                    StatusMessage = "Welcome Back! You were last in Shimla.";
                }
                else if (LoadingStatus == GameLoadingStatus.Won)
                {
                    StatusMessage = "Great job! Next you go to Shimla!";
                }
                else
                {
                    StatusMessage = "So close! Try Shimla again.";
                }
                break;
            case 4:
                if (LoadingStatus == GameLoadingStatus.NewGame)
                {
                    StatusMessage = "Welcome Back! You were last in Bangalore.";
                }
                else if (LoadingStatus == GameLoadingStatus.Won)
                {
                    StatusMessage = "Great job! Next you go to Bangalore!";
                }
                else
                {
                    StatusMessage = "So close! Try Bangalore again.";
                }
                break;
            case 5:
                if (LoadingStatus == GameLoadingStatus.NewGame)
                {
                    StatusMessage = "Welcome Back! You were last Fighting with Kalisura.";
                }
                else if (LoadingStatus == GameLoadingStatus.Won)
                {
                    StatusMessage = "Great job! Next you fight with Kalisura!";
                }
                else
                {
                    StatusMessage = "So close! Try fighting with Kalisura again.";
                }
                break;
            default:
                StatusMessage = "You're a legend!";
                break;
        }

        StatusMessage += "\nPress Enter to continue.";
    }



    public static void UpdateHighestRound(int newRound)
    {
        if (newRound > HighestRound)
        {
            HighestRound = newRound;
        }
    }

    public static void UpdateHighestScore(int newScore)
    {
        if (newScore > HighestScore)
        {
            HighestScore = newScore;
        }
    }

    public static void SaveData()
    {
        // Save data back to PlayerPrefs
        PlayerPrefs.SetInt("HighestRound", HighestRound);
        PlayerPrefs.SetInt("HighestScore", HighestScore);
        PlayerPrefs.Save();
    }
}
