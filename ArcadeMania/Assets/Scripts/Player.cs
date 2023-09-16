using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int coins = 0;
    public float speed = 5.0f;

    [SerializeField] int lives = 3;

    [SerializeField] private TMPro.TextMeshProUGUI coinsAmount, livesAmount;

    public GameObject door;
    // Start is called before the first frame update

    Vector3 initialPosition;
    void Start()
    {
        livesAmount.text = "Lives: " + lives;
        initialPosition = transform.position;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        if (coins == 3)
        {
            Destroy(door);
        }

    }

    void LoadMainMenuWithWin()
    {
        LoadMainMenu(true);
    }

    void LoadMainMenuWithLoss()
    {
        LoadMainMenu(false);
    }
    void LoadMainMenu(bool won)
    {

        GameData.UpdateHighestRound(3);

        if (won)
        {
            GameData.LoadingStatus = GameLoadingStatus.Won;
        }
        else
        {
            GameData.LoadingStatus = GameLoadingStatus.Lost;
        }
        GameData.SetStatusMessage();
        GameData.SaveData();

        // Load the intro scene
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            coins++;

            coinsAmount.text = "Coins: " + coins;
            Destroy(other.gameObject);

            if (coins == 3)
            {
                // All coins collected
            }
        }

        if (other.tag == "MainKey")
        {

            Destroy(other.gameObject);
            Invoke("LoadMainMenuWithWin", 2.0f);

        }
        if (other.tag == "Fire")
        {
            lives--;
            livesAmount.text = "Lives: " + lives;
            transform.position = initialPosition;

            if (lives <= 0)
            {
                Invoke("LoadMainMenuWithLoss", 0.2f);
            }
        }
    }
}
