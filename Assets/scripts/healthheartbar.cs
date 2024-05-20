using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthheartbar : MonoBehaviour
{
    public GameObject heartPrefab;
    public healthmanager Healthmanager;
    List<healthheart> hearts = new List<healthheart>();

    private void OnEnable()
    {
        healthmanager.OnPlayerDamaged += DrawHearts;
        //healthmanager.OnPlayerhealing += DrawHearts;
    }

     private void OnDisable()
    {
        healthmanager.OnPlayerDamaged -= DrawHearts;
        //healthmanager.OnPlayerhealing += DrawHearts;
    }

    void Start()
    {
        DrawHearts();
    }



    public void DrawHearts()
    {
        ClearHearts();

        float maxhealthRemainder = Healthmanager.maxhealth % 2;
        int heartstomake = (int)(Healthmanager.maxhealth / 2 + maxhealthRemainder);
        for (int i = 0; i < heartstomake; i++)
        {
            CreateHeart();
        }

        for(int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder =(int)Mathf.Clamp(Healthmanager.health - (i*2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
        }
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
