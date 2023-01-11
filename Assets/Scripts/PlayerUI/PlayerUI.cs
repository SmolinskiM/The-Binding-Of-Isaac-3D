using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    private Player player;

    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI keyText;
    [SerializeField] private TextMeshProUGUI bombText;

    private void Awake()
    {
        player = Player.Instance;
    }

    private void Start()
    {
        UpdateColectable();
    }

    private void UpdateColectable()
    {
        moneyText.text = "X " + player.Money;
        keyText.text = "X " + player.Key;
        bombText.text = "X " + player.Bomb;
    }
}