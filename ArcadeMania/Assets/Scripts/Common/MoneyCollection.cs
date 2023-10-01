using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCollection : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            GameData.Money += 1;
            AudioManager.instance.PlayCoinSound();
            moneyText.text = GameData.Money.ToString();
            Destroy(gameObject);
        }
    }
}
