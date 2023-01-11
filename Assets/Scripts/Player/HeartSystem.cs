using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeartSystem : MonoBehaviour
{
    private List<Heart> heartsRedList = new List<Heart>();
    private List<Heart> heartsColoredList = new List<Heart>();

    public Action OnUpdateHearts;

    public Action OnTakeDmageOnRedHeart;
    public Action OnTakeDmageOnBlackHeart;

    public List<Heart> HeartsRedList { get { return heartsRedList; } }
    public List<Heart> HeartsColoredList { get { return heartsColoredList; } }

    public void AddHeartContener()
    {
        heartsRedList.Insert(0, new Heart(HeartColor.Red, HeartSize.Full));
        OnUpdateHearts?.Invoke();
    }

    public void DeleteHeartContener()
    {
        heartsRedList.Remove(heartsRedList[0]);
        OnUpdateHearts?.Invoke();
    }

    public void AddHeart(Heart heart)
    {
        if (heart.heartColor == HeartColor.Red)
        {
            AddRedHeart(heart);
        }
        else
        {
            AddColoredHeart(heart);
        }
        OnUpdateHearts?.Invoke();
    }

    public void TakeDamage(int damageTaken)
    {
        if (heartsColoredList.Count == 0)
        {
            TakeDamageOnRedHeart(damageTaken);
        }
        else
        {
            TakeDamageOnColoredHeart(damageTaken);
        }
        OnUpdateHearts?.Invoke();
    }

    private void AddRedHeart(Heart heart)
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

            if (heart.heartSize == HeartSize.Empty)
            {
                return;
            }
        }
    }

    private void AddColoredHeart(Heart heart)
    {
        if(heartsColoredList.Count == 0)
        {
            heartsColoredList.Add(heart);
            return;
        }

        if (heartsColoredList.Last().heartSize == HeartSize.Half)
        {
            heartsColoredList.Last().heartSize = HeartSize.Full;
            heart.heartSize--;
        }

        if(heart.heartSize == HeartSize.Empty)
        {
            return;
        }

        heartsColoredList.Add(heart);
    }

    private void TakeDamageOnRedHeart(int damageTaken)
    {
        for (int i = heartsRedList.Count - 1; i >= 0; i--)
        {
            if (heartsRedList[i].heartSize == HeartSize.Empty)
            {
                continue;
            }

            if (heartsRedList[i].heartSize == HeartSize.Half)
            {
                heartsRedList[i].heartSize--;
                damageTaken--;
            }
            else
            {
                if(damageTaken > 1)
                {
                    damageTaken -= (int)heartsRedList[i].heartSize;
                    heartsRedList[i].heartSize = HeartSize.Empty;
                }
                else
                {
                    heartsRedList[i].heartSize -= damageTaken;
                    damageTaken--;
                }
            }

            OnTakeDmageOnRedHeart?.Invoke();

            if (damageTaken == 0)
            {
                return;
            }

        }
    }

    private void TakeDamageOnColoredHeart(int damageTaken)
    {
        while(damageTaken > 0)
        {
            if(heartsColoredList.Count == 0)
            {
                TakeDamageOnRedHeart(damageTaken);
                return;
            }

            if (heartsColoredList.Last().heartSize == HeartSize.Half)
            {
                heartsColoredList.Last().heartSize = HeartSize.Empty;
                damageTaken--;
            }
            else
            {
                if (damageTaken > 1)
                {
                    damageTaken -= (int)heartsColoredList.Last().heartSize;
                    heartsColoredList.Last().heartSize = HeartSize.Empty;
                }
                else
                {
                    heartsColoredList.Last().heartSize -= damageTaken;
                    damageTaken--;
                }
            }

            if(heartsColoredList.Last().heartSize == HeartSize.Empty)
            {
                if(heartsColoredList.Last().heartColor == HeartColor.Black)
                {
                    OnTakeDmageOnBlackHeart?.Invoke();
                }

                heartsColoredList.Remove(heartsColoredList.Last());
            }
        }
    }
}
