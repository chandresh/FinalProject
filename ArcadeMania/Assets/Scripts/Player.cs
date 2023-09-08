using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int coins = 0;
    public float speed = 5.0f;

    public Text keyAmount;
    public Text youWin;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
    void LoadNextScene()
    {
        // Load the intro scene
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            coins++;
            keyAmount.text = "Coins: " + coins;
            Destroy(other.gameObject);

            if (coins == 3)
            {
                youWin.text = "Get the key";
            }
        }

        if (other.tag == "MainKey")
        {
            youWin.text = "Go to Next Level";
            Destroy(other.gameObject);
            // Load the next scene after 2 seconds
            Invoke("LoadNextScene", 2f);
        }
        if (other.tag == "Fire")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
