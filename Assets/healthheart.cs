using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthheart : MonoBehaviour
{
  public Sprite fullheart, halfheart;
    Image heartImage;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void SetHeartImage(HeartStatus status)
    {
        switch(status)
        {
            case HeartStatus.full:
            heartImage.sprite = fullheart;
            break;
            case HeartStatus.half:
            heartImage.sprite = halfheart; break;
        }
    }

}

public enum HeartStatus
{
    full = 0,
    half = 1

}