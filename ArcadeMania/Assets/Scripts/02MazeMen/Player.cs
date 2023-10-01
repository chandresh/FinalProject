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
        HandleMovement();
        CheckCoinCount();
    }
    void HandleMovement()
    {
        float moveX = 0;
        float moveY = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -speed;
        if (Input.GetKey(KeyCode.RightArrow)) moveX = speed;
        if (Input.GetKey(KeyCode.UpArrow)) moveY = speed;
        if (Input.GetKey(KeyCode.DownArrow)) moveY = -speed;

        transform.Translate(moveX * Time.deltaTime, moveY * Time.deltaTime, 0);
    }

    void CheckCoinCount()
    {
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
            // Play the Game Won Sound
            AudioManager.instance.PlayRoundWonSound();
            // Add 3 coins won in this round to the player's money
            GameData.Money += 3;
            GameData.LoadingStatus = GameLoadingStatus.Won;
        }
        else
        {
            GameData.LoadingStatus = GameLoadingStatus.Lost;
            AudioManager.instance.PlayDeathSound();
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
            // Play the coin sound
            AudioManager.instance.PlayCoinSound();
            coins++;
            coinsAmount.text = "Coins: " + coins;
            Destroy(other.gameObject);

            if (coins == 3)
            {
                AudioManager.instance.PlayTeleportSound();
            }
        }

        if (other.tag == "MainKey")
        {
            AudioManager.instance.PlayRoundWonSound();
            Destroy(other.gameObject);
            Invoke("LoadMainMenuWithWin", 0.5f);

        }
        if (other.tag == "Fire")
        {
            AudioManager.instance.PlayBulletHitSound();
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
