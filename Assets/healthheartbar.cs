using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthheartbar : MonoBehaviour
{
    public GameObject heartPrefab;
    public healthmanager Healthmanager;
    List<healthheart> hearts = new List<healthheart>();


    public void DrawHearts()
    {
        ClearHearts();

        float maxhealthRemainder = Healthmanager.maxhealth % 2;
        int heartstomake = (int)(Healthmanager.maxhealth / 2 + maxhealthRemainder);
    }
    public void CreateHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        healthheart heartComponent = newHeart.GetComponent<healthheart>();
        heartComponent.SetHeartImage(HeartStatus.full);
        hearts.Add(heartComponent);
    }

    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<healthheart>();
    }
}
