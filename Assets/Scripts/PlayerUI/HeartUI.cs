using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    private Image heartImage;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void SetImage(Sprite heartImage, Color heartColor)
    {
        this.heartImage.sprite = heartImage;
        this.heartImage.color = heartColor;
    }
}
