using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    private HeartDisplay heartDisplay;
    private Player player;

    private TextMeshProUGUI moneyText;
    private TextMeshProUGUI keyText;
    private TextMeshProUGUI bombText;

    private void Start()
    {
        heartDisplay = GetComponent<HeartDisplay>();
    }

    private void UpdateColectable()
    {
        moneyText.text = "X " + player.Money;
        keyText.text = "X " + player.Key;
        bombText.text = "X " + player.Bomb;
    }
}