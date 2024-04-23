using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthheart : MonoBehaviour
{
  public Sprite fullheart, halfheart, emptyheart;
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
            case HeartStatus.empty:
            heartImage.sprite = emptyheart; break;
        }
    }

}

public enum HeartStatus
{
    empty = 0,
    half = 1,
    full = 2,

}