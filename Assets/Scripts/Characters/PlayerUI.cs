using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Transform heartHolder;
    [SerializeField] private Transform DisableHeartHolder;

    [SerializeField] private Image heartImagePrefab;

    [SerializeField] private Sprite emptyHeartSprite;
    [SerializeField] private Sprite halfHeartSprite;
    [SerializeField] private Sprite fullHeartSprite;

    private Dictionary<HeartSize, Sprite> heartSizeDictionary = new Dictionary<HeartSize, Sprite>();
    private Dictionary<HeartColor, Color> heartColorDictionary = new Dictionary<HeartColor, Color>();

    private ObjectPooling<Image> objectPooling;
    private List<HeartData> heartsRedList = new List<HeartData>();
    private List<HeartData> heartsColoredList = new List<HeartData>();

    private void Awake()
    {
        objectPooling = new ObjectPooling<Image>(heartImagePrefab, heartHolder, OnTake, OnRelease);
    }

    private void Start()
    {
        heartSizeDictionary.Add(HeartSize.Full, fullHeartSprite);
        heartSizeDictionary.Add(HeartSize.Half, halfHeartSprite);
        heartSizeDictionary.Add(HeartSize.Empty, emptyHeartSprite);

        heartColorDictionary.Add(HeartColor.Red, Color.red);
        heartColorDictionary.Add(HeartColor.Blue, Color.blue);
        heartColorDictionary.Add(HeartColor.Black, new Color((int)225 / 255, (int)225 / 255, (int)225 / 255));
    }

    private void Update()
    {
        Debug.Log(heartsRedList.Count + " " + heartsColoredList.Count);
    }

    public void AddHeartContener()
    {
        Image heartContenerImage = objectPooling.Pool.Get();

        heartContenerImage.sprite = heartSizeDictionary[HeartSize.Full];
        heartContenerImage.color = heartColorDictionary[HeartColor.Red];
        heartContenerImage.transform.SetAsFirstSibling();

        heartsRedList.Insert(0, new HeartData(HeartColor.Red, HeartSize.Full));
    }

    public void AddHeart(HeartData heart)
    {
        if (heart.heartColor == HeartColor.Red)
        {
            for (int i = 0; i < heartsRedList.Count; i++)
            {
                if (heartsRedList[i].heartSize == HeartSize.Full)
                {
                    continue;
                }

                if (heartsRedList[i].heartSize == HeartSize.Empty)
                {
                    heartsRedList[i].heartSize = heart.heartSize;
                    heart.heartSize = HeartSize.Empty;
                }
                else
                {
                    heartsRedList[i].heartSize++;
                    heart.heartSize--;
                }

                Image heartRedImage = heartHolder.GetChild(i).GetComponent<Image>();
                heartRedImage.sprite = heartSizeDictionary[heartsRedList[i].heartSize];

                if (heart.heartSize == HeartSize.Empty)
                {
                    return;
                }
            }
            return;
        }

        Image heartColoredImage;

        for (int i = 0; i < heartsColoredList.Count; i++)
        {
            if (heartsColoredList[i].heartSize == HeartSize.Full)
            {
                continue;
            }

            if (heartsColoredList[i].heartSize == HeartSize.Half)
            {
                heartsColoredList[i].heartSize++;
                heartColoredImage = heartHolder.GetChild(i + heartsRedList.Count).GetComponent<Image>();
                heartColoredImage.sprite = heartSizeDictionary[heartsColoredList[i].heartSize];
                heart.heartSize--;

                if (heart.heartSize == HeartSize.Empty)
                {
                    return;
                }
            }
        }

        heartColoredImage = objectPooling.Pool.Get();

        heartColoredImage.color = heartColorDictionary[heart.heartColor];
        heartColoredImage.sprite = heartSizeDictionary[heart.heartSize];
        heartColoredImage.transform.SetAsLastSibling();
        heartsColoredList.Add(heart);
        return;
    }

    public void TakeDamage()
    {
        if (heartsColoredList.Count == 0)
        {
            //Take damager Red
            for (int i = heartsRedList.Count - 1; i >= 0; i--)
            {
                if (heartsRedList[i].heartSize != HeartSize.Empty)
                {
                    Image heartRedImage = heartHolder.GetChild(i).GetComponent<Image>();

                    heartsRedList[i].heartSize--;
                    heartRedImage.sprite = heartSizeDictionary[heartsRedList[i].heartSize];

                    return;
                }
            }
        }

        if (heartsColoredList[^1].heartSize == HeartSize.Half)
        {
            objectPooling.Pool.Release(heartHolder.GetChild(heartsRedList.Count + heartsColoredList.Count - 1).GetComponent<Image>());

            heartsColoredList.RemoveAt(heartsColoredList.Count - 1);
        }
        else if (heartsColoredList[^1].heartSize == HeartSize.Full)
        {
            Image heartColoredImage = heartHolder.GetChild(heartsRedList.Count + heartsColoredList.Count - 1).GetComponent<Image>();
            heartsColoredList[^1].heartSize--;
            heartColoredImage.sprite = heartSizeDictionary[HeartSize.Half];
        }
    }

    private void OnRelease(Image heart)
    {
        heart.gameObject.SetActive(false);
        heart.transform.SetParent(DisableHeartHolder);
    }

    private void OnTake(Image heart)
    {
        heart.gameObject.SetActive(true);
        heart.transform.SetParent(heartHolder);
    }
}