using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private HeartDisplay heartDisplay;

    private void Start()
    {
        heartDisplay = GetComponent<HeartDisplay>();
    }
}