using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartCount : MonoBehaviour
{
    private HeartSystem heartSystem;

    public Button addContenerButton;
    public Button deleteContenerButton;
    public Button addRedHeartButton;
    public Button addBlueHeartButton;
    public Button addHalfBlueHeartButton;
    public Button addBlackHeartButton;
    public Button addHalfBlackHeartButton;
    public Button takeDamageOneButton;
    public Button takeDamageTwoButton;
    public Button takeDamageThreeButton;

    private void Awake()
    {
        heartSystem = GetComponent<HeartSystem>();
        addContenerButton.onClick.AddListener(heartSystem.AddHeartContener);
        addRedHeartButton.onClick.AddListener(delegate { heartSystem.AddHeart(new Heart(HeartColor.Red, HeartSize.Full)); });
        addBlueHeartButton.onClick.AddListener(delegate { heartSystem.AddHeart(new Heart(HeartColor.Blue, HeartSize.Full)); });
        addHalfBlueHeartButton.onClick.AddListener(delegate { heartSystem.AddHeart(new Heart(HeartColor.Blue, HeartSize.Half)); });
        addBlackHeartButton.onClick.AddListener(delegate { heartSystem.AddHeart(new Heart(HeartColor.Black, HeartSize.Full)); });
        addHalfBlackHeartButton.onClick.AddListener(delegate { heartSystem.AddHeart(new Heart(HeartColor.Black, HeartSize.Half)); });
        deleteContenerButton.onClick.AddListener(heartSystem.DeleteHeartContener);
        takeDamageOneButton.onClick.AddListener(delegate { heartSystem.TakeDamage(1); });
        takeDamageTwoButton.onClick.AddListener(delegate { heartSystem.TakeDamage(2); });
        takeDamageThreeButton.onClick.AddListener(delegate { heartSystem.TakeDamage(3); });
    }
}
