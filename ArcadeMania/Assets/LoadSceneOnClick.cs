using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    [SerializeField] int level;

    GameData gameData;

    void Start()
    {
        gameData = new GameData();
    }

    void OnMouseDown()
    {

        if (level <= gameData.HighestRound)
        {
            SceneManager.LoadScene(sceneToLoad);
        }

    }

}
