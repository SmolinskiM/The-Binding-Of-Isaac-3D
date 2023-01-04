using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] private Transform heartHolder;

    [SerializeField] private HeartUI heartUI;

    [SerializeField] private Sprite emptyHeartSprite;
    [SerializeField] private Sprite halfHeartSprite;
    [SerializeField] private Sprite fullHeartSprite;

    [SerializeField] private HeartSystem heartSystem;

    private Dictionary<HeartSize, Sprite> spriteByHeartSize = new Dictionary<HeartSize, Sprite>();
    private Dictionary<HeartColor, Color> colorByHeartColor = new Dictionary<HeartColor, Color>();

    private List<HeartUI> heartsImageList = new List<HeartUI>();

    private void Awake()
    {
        heartSystem.OnUpdateHearts += UpdateHearts;
    }

    private void Start()
    {
        spriteByHeartSize.Add(HeartSize.Full, fullHeartSprite);
        spriteByHeartSize.Add(HeartSize.Half, halfHeartSprite);
        spriteByHeartSize.Add(HeartSize.Empty, emptyHeartSprite);

        colorByHeartColor.Add(HeartColor.Red, Color.red);
        colorByHeartColor.Add(HeartColor.Blue, Color.blue);
        colorByHeartColor.Add(HeartColor.Black, new Color((int)225/255, (int)225/255, (int) 225/255));
    }

    private void UpdateHearts()
    {
        int i = 0;

        foreach (Heart heart in heartSystem.HeartsRedList)
        {
            if(i > heartsImageList.Count - 1)
            {
                AddHeartToList(heart);
            }
            else
            {
                SetUpImage(i, heart);
            }

            i++;
        }

        foreach (Heart heart in heartSystem.HeartsColoredList)
        {
            if (i > heartsImageList.Count - 1)
            {
                AddHeartToList(heart);
            }
            else
            {
                SetUpImage(i, heart);
            }
            i++;
        }

        while (i < heartsImageList.Count)
        {
            HideHeart(heartsImageList[i]);
            i++;
        }
    }

    private void AddHeartToList(Heart heart)
    {
        HeartUI heartUI = CreateHeartImage();
        heartUI.SetImage(spriteByHeartSize[heart.heartSize], colorByHeartColor[heart.heartColor]);
        heartsImageList.Add(heartUI);
    }

    private void SetUpImage(int i, Heart heart)
    {
        heartsImageList[i].SetImage(spriteByHeartSize[heart.heartSize], colorByHeartColor[heart.heartColor]);
        ShowHeart(heartsImageList[i]);
    }

    private HeartUI CreateHeartImage()
    {
        HeartUI heartUI = Instantiate(this.heartUI, heartHolder.position, Quaternion.identity, heartHolder);
        return heartUI;
    }

    private void ShowHeart(HeartUI heartUI)
    {
        heartUI.gameObject.SetActive(true);
    }

    private void HideHeart(HeartUI heartUI)
    {
        heartUI.gameObject.SetActive(false);
    }
}
