using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    [SerializeField] string sceneToLoad;
    [SerializeField] int level;

    void OnMouseDown()
    {

        if (level <= GameData.HighestRound)
        {
            SceneManager.LoadScene(sceneToLoad);
        }

    }

}
