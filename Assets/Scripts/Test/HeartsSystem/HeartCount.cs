using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartCount : MonoBehaviour
{
    private HeartDisplay heartDisplay;

    public Button addContenerButton;
    public Button addColordHeart;
    public Button addRedHeart;
    public Button addHalfColordHeart;
    public Button takeDamage;

    private void Awake()
    {
        heartDisplay = GetComponent<HeartDisplay>();
        addContenerButton.onClick.AddListener(heartDisplay.AddHeartContener);
        addColordHeart.onClick.AddListener(delegate { heartDisplay.AddHeart(new HeartData(HeartColor.Blue, HeartSize.Full)); });
        addRedHeart.onClick.AddListener(delegate { heartDisplay.AddHeart(new HeartData(HeartColor.Red, HeartSize.Full)); });
        addHalfColordHeart.onClick.AddListener(delegate { heartDisplay.AddHeart(new HeartData(HeartColor.Blue, HeartSize.Half)); });
        takeDamage.onClick.AddListener(heartDisplay.TakeDamage);
    }
}
